-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jul 20, 2025 at 06:29 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `eshift_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `customers`
--

CREATE TABLE `customers` (
  `user_id` int(11) NOT NULL,
  `first_name` varchar(100) NOT NULL,
  `last_name` varchar(100) NOT NULL,
  `phone_number` varchar(20) NOT NULL,
  `address_line` varchar(255) NOT NULL,
  `city` varchar(100) NOT NULL,
  `postal_code` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `customers`
--

INSERT INTO `customers` (`user_id`, `first_name`, `last_name`, `phone_number`, `address_line`, `city`, `postal_code`) VALUES
(5, 'Fordor', 'Hogn', '123456789', 'Temple road, Yokshma', 'Galle', '80000'),
(7, 'Samabid', 'Fenexyy', '1234567892', 'ABC Road, Kurunduwatta', 'Galle', '80000'),
(11, 'Kagoc', 'Mytaemin', '1234567890', 'No 123, Poddala', 'Galle', '80000'),
(12, 'Vivey', 'Mytaemin', '1245678999', 'ABC Rd', 'Galle', '80000'),
(13, 'Celoko', 'Luxpolar', '1234567890', 'No 123, ABC Road, Thalpe', 'Galle', '80000'),
(14, 'Rewafoh', 'Kissgy', '1234567890', 'Baddegama', 'Galle', '80000'),
(15, 'Hekiseo', 'Kissgy', '1234567890', 'No:123, Thalpe', 'Galle', '80000'),
(16, 'Yokeh', 'Luxpolar', '1234567890', 'ABC Road, Galle', 'Galle', '80000'),
(17, 'John', 'Doe', '0777777777', 'ABC Road, Thalpe', 'Galle', '80000');

-- --------------------------------------------------------

--
-- Table structure for table `employees`
--

CREATE TABLE `employees` (
  `id` int(11) NOT NULL,
  `first_name` varchar(100) NOT NULL,
  `last_name` varchar(100) NOT NULL,
  `contact_number` varchar(20) NOT NULL,
  `position` enum('Driver','Assistant') NOT NULL,
  `license_number` varchar(50) DEFAULT NULL,
  `status` enum('Available','Assigned') NOT NULL DEFAULT 'Available'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `employees`
--

INSERT INTO `employees` (`id`, `first_name`, `last_name`, `contact_number`, `position`, `license_number`, `status`) VALUES
(1, 'Johnn', 'Doe', '0777234654', 'Driver', '1234567890', 'Assigned'),
(2, 'Elwin', 'Hopes', '0777654987', 'Assistant', 'N/A', 'Assigned');

-- --------------------------------------------------------

--
-- Table structure for table `jobs`
--

CREATE TABLE `jobs` (
  `id` int(11) NOT NULL,
  `customer_id` int(11) NOT NULL,
  `transport_unit_id` int(11) DEFAULT NULL,
  `pickup_location` text NOT NULL,
  `dropoff_location` text NOT NULL,
  `pickup_date` datetime NOT NULL,
  `load_size` varchar(50) NOT NULL,
  `description` text DEFAULT NULL,
  `status` enum('Pending','Approved','Rejected','Scheduled','OnGoing','Completed','Canceled') NOT NULL DEFAULT 'Pending',
  `total_cost` decimal(10,2) DEFAULT NULL,
  `estimated_hours` int(11) DEFAULT NULL,
  `rejection_reason` text DEFAULT NULL,
  `created_at` timestamp NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `jobs`
--

INSERT INTO `jobs` (`id`, `customer_id`, `transport_unit_id`, `pickup_location`, `dropoff_location`, `pickup_date`, `load_size`, `description`, `status`, `total_cost`, `estimated_hours`, `rejection_reason`, `created_at`, `updated_at`) VALUES
(17, 15, 2, 'No:123, Thalpe, Galle', 'NO:123, ABC Lance, Colombo', '2025-07-21 20:31:41', 'Small (1-2 rooms)', 'Please call me before handing over the package.', 'Scheduled', 10000.00, 5, NULL, '2025-07-20 15:02:19', '2025-07-20 15:04:14'),
(18, 16, NULL, 'ABC Road, Galle, Galle', 'ABC Road, Thalpe, Galle', '2025-07-21 21:55:46', 'Small (1-2 rooms)', '', 'Pending', NULL, NULL, NULL, '2025-07-20 16:26:10', '2025-07-20 16:26:10');

-- --------------------------------------------------------

--
-- Table structure for table `transport_units`
--

CREATE TABLE `transport_units` (
  `id` int(11) NOT NULL,
  `unit_name` varchar(100) NOT NULL,
  `truck_id` int(11) NOT NULL,
  `driver_id` int(11) NOT NULL,
  `assistant_id` int(11) NOT NULL,
  `status` enum('Available','OnJob') NOT NULL DEFAULT 'Available'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `transport_units`
--

INSERT INTO `transport_units` (`id`, `unit_name`, `truck_id`, `driver_id`, `assistant_id`, `status`) VALUES
(2, 'Team-001', 1, 1, 2, 'Available');

-- --------------------------------------------------------

--
-- Table structure for table `trucks`
--

CREATE TABLE `trucks` (
  `id` int(11) NOT NULL,
  `model` varchar(100) NOT NULL,
  `license_plate` varchar(20) NOT NULL,
  `status` enum('Available','Assigned') NOT NULL DEFAULT 'Available'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `trucks`
--

INSERT INTO `trucks` (`id`, `model`, `license_plate`, `status`) VALUES
(1, 'Mahindra Bolero', 'LN-1020', 'Assigned'),
(2, 'Demo Batta', 'LN-2322', 'Available'),
(3, 'Mahindra Bolero', 'LN-1021', 'Available');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `email` varchar(255) NOT NULL,
  `password_hash` varchar(255) NOT NULL,
  `user_type` enum('Customer','Admin') NOT NULL,
  `is_email_verified` tinyint(1) NOT NULL DEFAULT 0,
  `created_at` timestamp NULL DEFAULT current_timestamp(),
  `updated_at` timestamp NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `email`, `password_hash`, `user_type`, `is_email_verified`, `created_at`, `updated_at`) VALUES
(5, 'fadem68637@fenexxy.com', '$2a$11$ERgWIJM3QkraqY98dFs9peaYXV1m4SUxArdQ5oYLAM9G6VXy7uaze', 'Customer', 0, '2025-07-11 01:38:03', '2025-07-11 01:38:03'),
(7, 'samabi5174@fenexy.com', '$2a$11$RJ2ESfVPzNs51X52h8Szh.70Dbe.vctmpMv/LQ0q/vYexifpN9T/S', 'Customer', 1, '2025-07-11 02:45:38', '2025-07-11 15:49:47'),
(10, 'admin@eshift.com', '$2a$11$te2XJ6I1brxutjl191sUb.SP9uD7SX.nVWRdI.tsct1oCzezSrjPW', 'Admin', 1, '2025-07-15 18:25:11', '2025-07-15 18:25:11'),
(11, 'kagoc87584@mytaemin.com', '$2a$11$7uZXSDZyM35UByN49JEwfed6o9pG1w1sSpqM29Bs1GQ7eOtG5TDvC', 'Customer', 1, '2025-07-17 14:16:20', '2025-07-17 15:04:20'),
(12, 'vivey45096@mytaemin.com', '$2a$11$lPFHw6Ic1fvi08/4aYeoqOo/CndJLrtLlJZLRQq1tjWISXZc.N5/6', '', 1, '2025-07-17 15:36:13', '2025-07-17 15:36:32'),
(13, 'celoko9350@luxpolar.com', '$2a$11$biceTTIGrgOjC0ZdBeT0SeVDS7Bh4SHjOM95PYXwrhoark12Yvsv.', 'Customer', 1, '2025-07-19 03:15:32', '2025-07-19 03:58:01'),
(14, 'rewafoh808@kissgy.com', '$2a$11$PcqE6w3So85.pnT9UshLOez16jvMoviYUftq7Moaps9Sogokj5EDy', 'Customer', 1, '2025-07-19 03:55:20', '2025-07-19 09:21:07'),
(15, 'hekise9444@kissgy.com', '$2a$11$5B/ZQ5KgGDrNrfD348s8POa2KvbPw9b05o6KZ73GLFuJjjV6xm6nq', 'Customer', 1, '2025-07-19 09:26:45', '2025-07-20 16:11:59'),
(16, 'yokeh34854@luxpolar.com', '$2a$11$/2P/UBrzcoTJNfWj13OU3eUD0ShKHc.7ElXyFZbDpNes83pZlgD/G', 'Customer', 1, '2025-07-20 16:25:01', '2025-07-20 16:25:20'),
(17, 'john@doe.com', '$2a$11$PFJsE.ufFYFVjO6.LzDcSOCj/niSGCKs/Ihi.MSyW4PNZUPdqR.p2', 'Customer', 0, '2025-07-20 16:27:45', '2025-07-20 16:27:45');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`user_id`);

--
-- Indexes for table `employees`
--
ALTER TABLE `employees`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `jobs`
--
ALTER TABLE `jobs`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_jobs_customers_idx` (`customer_id`),
  ADD KEY `fk_jobs_transport_units_idx` (`transport_unit_id`);

--
-- Indexes for table `transport_units`
--
ALTER TABLE `transport_units`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `unit_name_UNIQUE` (`unit_name`),
  ADD UNIQUE KEY `truck_id_UNIQUE` (`truck_id`),
  ADD UNIQUE KEY `driver_id_UNIQUE` (`driver_id`),
  ADD UNIQUE KEY `assistant_id_UNIQUE` (`assistant_id`);

--
-- Indexes for table `trucks`
--
ALTER TABLE `trucks`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `license_plate_UNIQUE` (`license_plate`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `email_UNIQUE` (`email`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `employees`
--
ALTER TABLE `employees`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `jobs`
--
ALTER TABLE `jobs`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT for table `transport_units`
--
ALTER TABLE `transport_units`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `trucks`
--
ALTER TABLE `trucks`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `customers`
--
ALTER TABLE `customers`
  ADD CONSTRAINT `fk_customers_users` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Constraints for table `jobs`
--
ALTER TABLE `jobs`
  ADD CONSTRAINT `fk_jobs_customers` FOREIGN KEY (`customer_id`) REFERENCES `customers` (`user_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_jobs_transport_units` FOREIGN KEY (`transport_unit_id`) REFERENCES `transport_units` (`id`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Constraints for table `transport_units`
--
ALTER TABLE `transport_units`
  ADD CONSTRAINT `fk_transport_units_employees_assistant` FOREIGN KEY (`assistant_id`) REFERENCES `employees` (`id`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_transport_units_employees_driver` FOREIGN KEY (`driver_id`) REFERENCES `employees` (`id`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_transport_units_trucks` FOREIGN KEY (`truck_id`) REFERENCES `trucks` (`id`) ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
