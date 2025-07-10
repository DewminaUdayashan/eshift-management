-- E-Shift Database Creation Script
-- This script creates all the necessary tables and defines their relationships.

-- -----------------------------------------------------
-- Table `users`
-- Stores core login information for all user types.
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `users` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `email` VARCHAR(255) NOT NULL,
  `password_hash` VARCHAR(255) NOT NULL,
  `user_type` ENUM('Customer', 'Admin') NOT NULL,
  `is_email_verified` TINYINT(1) NOT NULL DEFAULT 0,
  `created_at` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `email_UNIQUE` (`email` ASC));


-- -----------------------------------------------------
-- Table `customers`
-- Stores profile information for customers, linked one-to-one with the users table.
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `customers` (
  `user_id` INT NOT NULL,
  `first_name` VARCHAR(100) NOT NULL,
  `last_name` VARCHAR(100) NOT NULL,
  `phone_number` VARCHAR(20) NOT NULL,
  `address_line` VARCHAR(255) NOT NULL,
  `city` VARCHAR(100) NOT NULL,
  `postal_code` VARCHAR(20) NOT NULL,
  PRIMARY KEY (`user_id`),
  CONSTRAINT `fk_customers_users`
    FOREIGN KEY (`user_id`)
    REFERENCES `users` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE);


-- -----------------------------------------------------
-- Table `user_otps`
-- Stores one-time passwords for email verification and password resets.
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `user_otps` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `user_id` INT NOT NULL,
  `otp_code` VARCHAR(6) NOT NULL,
  `otp_type` ENUM('Verification', 'Reset') NOT NULL,
  `expires_at` DATETIME NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_user_otps_users_idx` (`user_id` ASC),
  CONSTRAINT `fk_user_otps_users`
    FOREIGN KEY (`user_id`)
    REFERENCES `users` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE);


-- -----------------------------------------------------
-- Table `trucks`
-- Stores the company's fleet of vehicles.
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `trucks` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `model` VARCHAR(100) NOT NULL,
  `license_plate` VARCHAR(20) NOT NULL,
  `status` ENUM('Available', 'Assigned') NOT NULL DEFAULT 'Available',
  PRIMARY KEY (`id`),
  UNIQUE INDEX `license_plate_UNIQUE` (`license_plate` ASC));


-- -----------------------------------------------------
-- Table `employees`
-- Stores staff information for drivers and assistants.
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `employees` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `first_name` VARCHAR(100) NOT NULL,
  `last_name` VARCHAR(100) NOT NULL,
  `contact_number` VARCHAR(20) NOT NULL,
  `position` ENUM('Driver', 'Assistant') NOT NULL,
  `license_number` VARCHAR(50) NULL,
  `status` ENUM('Available', 'Assigned') NOT NULL DEFAULT 'Available',
  PRIMARY KEY (`id`));


-- -----------------------------------------------------
-- Table `transport_units`
-- Groups resources into operational teams. Ensures a resource can only be in one unit at a time.
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `transport_units` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `unit_name` VARCHAR(100) NOT NULL,
  `truck_id` INT NOT NULL,
  `driver_id` INT NOT NULL,
  `assistant_id` INT NOT NULL,
  `status` ENUM('Available', 'OnJob') NOT NULL DEFAULT 'Available',
  PRIMARY KEY (`id`),
  UNIQUE INDEX `unit_name_UNIQUE` (`unit_name` ASC),
  UNIQUE INDEX `truck_id_UNIQUE` (`truck_id` ASC),
  UNIQUE INDEX `driver_id_UNIQUE` (`driver_id` ASC),
  UNIQUE INDEX `assistant_id_UNIQUE` (`assistant_id` ASC),
  CONSTRAINT `fk_transport_units_trucks`
    FOREIGN KEY (`truck_id`)
    REFERENCES `trucks` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `fk_transport_units_employees_driver`
    FOREIGN KEY (`driver_id`)
    REFERENCES `employees` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `fk_transport_units_employees_assistant`
    FOREIGN KEY (`assistant_id`)
    REFERENCES `employees` (`id`)
    ON DELETE RESTRICT
    ON UPDATE CASCADE);


-- -----------------------------------------------------
-- Table `jobs`
-- The central table for managing all customer shifting jobs.
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `jobs` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `customer_id` INT NOT NULL,
  `transport_unit_id` INT NULL,
  `pickup_location` TEXT NOT NULL,
  `dropoff_location` TEXT NOT NULL,
  `pickup_date` DATETIME NOT NULL,
  `load_size` VARCHAR(50) NOT NULL,
  `description` TEXT NULL,
  `status` ENUM('Pending', 'Approved', 'Rejected', 'Scheduled', 'OnGoing', 'Completed', 'Canceled') NOT NULL DEFAULT 'Pending',
  `total_cost` DECIMAL(10,2) NULL,
  `estimated_hours` INT NULL,
  `rejection_reason` TEXT NULL,
  `created_at` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP,
  `updated_at` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  INDEX `fk_jobs_customers_idx` (`customer_id` ASC),
  INDEX `fk_jobs_transport_units_idx` (`transport_unit_id` ASC),
  CONSTRAINT `fk_jobs_customers`
    FOREIGN KEY (`customer_id`)
    REFERENCES `customers` (`user_id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_jobs_transport_units`
    FOREIGN KEY (`transport_unit_id`)
    REFERENCES `transport_units` (`id`)
    ON DELETE SET NULL
    ON UPDATE CASCADE);

-- -----------------------------------------------------
-- Table `notifications`
-- Stores notifications for users, such as job status updates.
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `notifications` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `user_id` INT NOT NULL,
  `message` TEXT NOT NULL,
  `is_read` TINYINT(1) NOT NULL DEFAULT 0,
  `created_at` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  INDEX `fk_notifications_users_idx` (`user_id` ASC),
  CONSTRAINT `fk_notifications_users`
    FOREIGN KEY (`user_id`)
    REFERENCES `users` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE);

