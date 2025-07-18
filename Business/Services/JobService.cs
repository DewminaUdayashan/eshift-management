using eshift_management.Core.Exceptions;
using eshift_management.Core.Repositories;
using eshift_management.Core.Services;
using eshift_management.Core.Services.Interfaces;
using eshift_management.Models;
using eshift_management.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eshift_management.Services
{
    /// <summary>
    /// Provides business logic for managing jobs. This single class implements
    /// role-specific interfaces for both Admins and Customers.
    /// </summary>
    public class JobService : IAdminJobService, ICustomerJobService
    {
        private readonly IJobRepository _jobRepository;
        private readonly ITransportUnitRepository _unitRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailService _emailService;

        /// <summary>
        /// Constructs the JobService with injected repositories.
        /// </summary>
        public JobService(IJobRepository jobRepository, ITransportUnitRepository unitRepository, IUserRepository userRepository, ICustomerRepository customerRepository, IEmailService emailService)
        {
            _jobRepository = jobRepository;
            _unitRepository = unitRepository;
            _userRepository = userRepository;
            _customerRepository = customerRepository;
            _emailService = emailService;
        }

        public async Task ApproveJobAsync(int jobId, decimal totalCost, int estimatedHours, int customerId)
        {
            var job = await _jobRepository.GetByIdAsync(jobId) ?? throw new KeyNotFoundException("Job not found.");
            if (job.Status != JobStatus.Pending) throw new InvalidOperationException("Only pending jobs can be approved.");

            job.TotalCost = totalCost;
            job.EstimatedHours = estimatedHours;
            job.Status = JobStatus.Approved;
            await _jobRepository.UpdateAsync(job);

            var user = await _userRepository.GetByIdAsync(customerId);
            var customer = await _customerRepository.GetByIdAsync(customerId);
            if (user != null && customer!=null)
            {
                string subject = $"Your E-Shift Job Has Been Approved! (Job #{jobId})";
                string body = $@"
                    <p>Great news! Your job request (ID: {jobId}) has been reviewed and approved by our team.</p>
                    <p>Here are the details:</p>
                    <ul>
                        <li><strong>Total Estimated Cost:</strong> {totalCost:N2} LKR</li>
                        <li><strong>Estimated Duration:</strong> {estimatedHours} hours</li>
                    </ul>
                    <p>We will notify you again once a transport unit has been scheduled for your move. You can view your job status at any time by logging into your account.</p>";

                await _emailService.SendEmailAsync(user.Email, subject, _emailService.GetEmailHtmlTemplate("Your Job is Approved!", body, customer.FirstName));
            }
        }

        public async Task RejectJobAsync(int jobId, string reason, int customerId)
        {
            await _jobRepository.UpdateJobStatusAsync(jobId, JobStatus.Rejected, reason);
            var user = await _userRepository.GetByIdAsync(customerId);
            var customer = await _customerRepository.GetByIdAsync(customerId);

            if (user != null && customer!=null)
            {
                string subject = $"Update on Your E-Shift Job Request (Job #{jobId})";
                string body = $@"
                    <p>We have reviewed your job request (ID: {jobId}). Unfortunately, we are unable to proceed at this time for the following reason:</p>
                    <p><strong><i>""{reason}""</i></strong></p>
                    <p>If you have any questions or would like to discuss this further, please don't hesitate to contact our support team.</p>";

                await _emailService.SendEmailAsync(user.Email, subject, _emailService.GetEmailHtmlTemplate("Job Request Update", body, customer.FirstName));
            }
        }

        public async Task DispatchJobAsync(int jobId, int customerId)
        {
            await _jobRepository.UpdateJobStatusAsync(jobId, JobStatus.OnGoing);
            var user = await _userRepository.GetByIdAsync(customerId);
            var customer = await _customerRepository.GetByIdAsync(customerId);

            if (user != null && customer!=null)
            {
                string subject = $"Your E-Shift Team is On The Way! (Job #{jobId})";
                string body = $@"
                    <p>Get ready! Our transport team has been dispatched for your job (ID: {jobId}) and is now on the way to your pickup location.</p>
                    <p>We look forward to providing you with a smooth and efficient move. You can track the status of your job in your E-Shift account.</p>";

                await _emailService.SendEmailAsync(user.Email, subject, _emailService.GetEmailHtmlTemplate("Your Move is In Progress!", body, customer.FirstName));
            }
        }

        public async Task CompleteJobAsync(int jobId, int customerId)
        {
            var job = await _jobRepository.GetByIdAsync(jobId) ?? throw new KeyNotFoundException("Job not found.");
            if (job.AssignedUnit == null) throw new InvalidOperationException("Cannot complete a job with no assigned unit.");

            await _jobRepository.UpdateJobStatusAsync(jobId, JobStatus.Completed);
            await _unitRepository.UpdateStatusAsync(job.AssignedUnit.Id, ResourceStatus.Available);

            var user = await _userRepository.GetByIdAsync(customerId);
            var customer = await _customerRepository.GetByIdAsync(customerId);

            if (user != null && customer!=null)
            {
                string subject = $"Your E-Shift Job is Complete! (Job #{jobId})";
                string body = $@"
                    <p>We're pleased to inform you that your job (ID: {jobId}) has been successfully completed. An invoice has been generated and is available in your account.</p>
                    <p>We hope you had a great experience with E-Shift Movers. Thank you for choosing us for your moving needs!</p>";

                await _emailService.SendEmailAsync(user.Email, subject, _emailService.GetEmailHtmlTemplate("Job Completed!", body, customer.FirstName));
            }
        }

        public Task<IEnumerable<Job>> GetAllJobsAsync(Dictionary<string, object>? filter = null, string? orderBy = null, bool isAscending = true) => _jobRepository.GetAllAsync(filter, orderBy, isAscending);

        public Task<Job?> GetJobByIdAsync(int id) => _jobRepository.GetByIdAsync(id);

        public async Task AssignTransportUnitAsync(int jobId, int unitId, bool forceAssignment = false)
        {
            var job = await _jobRepository.GetByIdAsync(jobId) ?? throw new KeyNotFoundException("Job not found.");
            if (job.Status != JobStatus.Approved && job.Status != JobStatus.Scheduled) throw new InvalidOperationException("A unit can only be assigned to an approved or already scheduled job.");
            if (!forceAssignment)
            {
                bool isConflict = await _jobRepository.IsUnitScheduledOnDateAsync(unitId, job.PickupDate, job.Id);
                if (isConflict) throw new UnitConflictException($"This unit is already scheduled for another job on {job.PickupDate:d}.");
            }
            if (job.AssignedUnit != null && job.AssignedUnit.Id != unitId)
            {
                await _unitRepository.UpdateStatusAsync(job.AssignedUnit.Id, ResourceStatus.Available);
            }
            await _jobRepository.AssignTransportUnitAsync(jobId, unitId);
        }

        public async Task CancelJobAsync(int jobId)
        {
            var job = await _jobRepository.GetByIdAsync(jobId) ?? throw new KeyNotFoundException("Job not found.");
            if (job.AssignedUnit != null)
            {
                await _unitRepository.UpdateStatusAsync(job.AssignedUnit.Id, ResourceStatus.Available);
            }
            await _jobRepository.UpdateJobStatusAsync(jobId, JobStatus.Canceled);
        }

        public Task<IEnumerable<Job>> GetJobsByCustomerAsync(int customerId) => _jobRepository.GetJobsByCustomerAsync(customerId);

        public Task<int> CreateJobAsync(Job job)
        {
            job.Status = JobStatus.Pending;
            return _jobRepository.AddAsync(job);
        }

        public async Task UpdateJobAsync(Job job)
        {
            var existingJob = await _jobRepository.GetByIdAsync(job.Id) ?? throw new KeyNotFoundException("Job not found.");
            if (existingJob.Status != JobStatus.Pending) throw new InvalidOperationException("You can no longer edit this job as it has already been reviewed by an administrator.");
            await _jobRepository.UpdateAsync(job);
        }

        public async Task CancelPendingJobAsync(int jobId, int customerId)
        {
            var job = await _jobRepository.GetByIdAsync(jobId) ?? throw new KeyNotFoundException("Job not found.");
            if (job.Customer.UserId != customerId) throw new UnauthorizedAccessException("You are not authorized to cancel this job.");
            if (job.Status != JobStatus.Pending) throw new InvalidOperationException("Only pending jobs can be canceled.");
            await _jobRepository.UpdateJobStatusAsync(jobId, JobStatus.Canceled);
        }
    }
}
