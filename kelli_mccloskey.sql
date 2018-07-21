-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Jul 21, 2018 at 12:01 AM
-- Server version: 5.6.38
-- PHP Version: 7.2.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `kelli_mccloskey`
--
CREATE DATABASE IF NOT EXISTS `kelli_mccloskey` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `kelli_mccloskey`;

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

CREATE TABLE `clients` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `clients`
--

INSERT INTO `clients` (`id`, `name`) VALUES
(7, 'Ryan');

-- --------------------------------------------------------

--
-- Table structure for table `clients_stylists`
--

CREATE TABLE `clients_stylists` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `client_id` int(11) NOT NULL,
  `stylist_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `clients_stylists`
--

INSERT INTO `clients_stylists` (`id`, `client_id`, `stylist_id`) VALUES
(10, 5, 14),
(11, 5, 14),
(12, 5, 15),
(13, 7, 14);

-- --------------------------------------------------------

--
-- Table structure for table `services`
--

CREATE TABLE `services` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `services`
--

INSERT INTO `services` (`id`, `name`) VALUES
(1, 'Styling'),
(2, 'Coloring'),
(4, 'Haircuts');

-- --------------------------------------------------------

--
-- Table structure for table `services_stylists`
--

CREATE TABLE `services_stylists` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `service_id` int(11) NOT NULL,
  `stylist_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `services_stylists`
--

INSERT INTO `services_stylists` (`id`, `service_id`, `stylist_id`) VALUES
(7, 1, 12),
(8, 1, 14),
(9, 4, 15),
(10, 2, 15),
(11, 1, 15),
(12, 2, 16),
(13, 4, 16);

-- --------------------------------------------------------

--
-- Table structure for table `stylists`
--

CREATE TABLE `stylists` (
  `id` bigint(20) UNSIGNED NOT NULL,
  `name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stylists`
--

INSERT INTO `stylists` (`id`, `name`) VALUES
(14, 'Gary'),
(15, 'Manny'),
(16, 'Stacy');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`);

--
-- Indexes for table `clients_stylists`
--
ALTER TABLE `clients_stylists`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`);

--
-- Indexes for table `services`
--
ALTER TABLE `services`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`);

--
-- Indexes for table `services_stylists`
--
ALTER TABLE `services_stylists`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`);

--
-- Indexes for table `stylists`
--
ALTER TABLE `stylists`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `id` (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clients`
--
ALTER TABLE `clients`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `clients_stylists`
--
ALTER TABLE `clients_stylists`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `services`
--
ALTER TABLE `services`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `services_stylists`
--
ALTER TABLE `services_stylists`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- AUTO_INCREMENT for table `stylists`
--
ALTER TABLE `stylists`
  MODIFY `id` bigint(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
