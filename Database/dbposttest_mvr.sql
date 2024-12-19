-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 29, 2024 at 02:42 PM
-- Server version: 10.4.24-MariaDB
-- PHP Version: 8.1.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbposttest_mvr`
--

-- --------------------------------------------------------

--
-- Table structure for table `alat`
--

CREATE TABLE `alat` (
  `id_alat` int(11) NOT NULL,
  `nama_alat` varchar(50) NOT NULL,
  `tipe_alat` varchar(50) NOT NULL,
  `tanggal_beli` date NOT NULL,
  `jumlah_alat` int(11) NOT NULL,
  `status_kondisi` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `alat`
--

INSERT INTO `alat` (`id_alat`, `nama_alat`, `tipe_alat`, `tanggal_beli`, `jumlah_alat`, `status_kondisi`) VALUES
(1, 'Bekho', 'UT7468', '2024-05-29', 80, '1'),
(2, 'Tadano', 'UT9989', '2024-05-29', 50, '0'),
(3, 'Forkliv', 'UT 8776', '2024-05-29', 20, '1'),
(4, 'Buldozer', 'UT55567', '2024-05-29', 40, '1');

-- --------------------------------------------------------

--
-- Table structure for table `jadwal_perawatan_alat`
--

CREATE TABLE `jadwal_perawatan_alat` (
  `id_jadwal_perawatan` int(11) NOT NULL,
  `id_alat` int(11) NOT NULL,
  `id_vendor` int(11) NOT NULL,
  `tanggal_perawatan` date NOT NULL,
  `qty` int(11) NOT NULL,
  `total_harga` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `jadwal_perawatan_alat`
--

INSERT INTO `jadwal_perawatan_alat` (`id_jadwal_perawatan`, `id_alat`, `id_vendor`, `tanggal_perawatan`, `qty`, `total_harga`) VALUES
(2, 3, 5, '2024-05-29', 20, 40000000);

-- --------------------------------------------------------

--
-- Table structure for table `vendor`
--

CREATE TABLE `vendor` (
  `id_vendor` int(11) NOT NULL,
  `nama_vendor` varchar(50) NOT NULL,
  `alamat` varchar(50) NOT NULL,
  `kontak` varchar(20) NOT NULL,
  `spesialis_perawatan` varchar(20) NOT NULL,
  `harga_perawatan` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `vendor`
--

INSERT INTO `vendor` (`id_vendor`, `nama_vendor`, `alamat`, `kontak`, `spesialis_perawatan`, `harga_perawatan`) VALUES
(1, 'PT. Mobi Trucks', 'Jl. Mbatukam No. 69', '6281653689', 'Airsus', '800000'),
(3, 'PT. United Tracktors Tbk', 'Jl. Bekasi', '628893784894', 'Ganti Oli mesin', '2000000'),
(5, 'PT. UD Trucks', 'Jl. Jambe Manok Wari', '6285830938', 'Full Service', '2000000');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `alat`
--
ALTER TABLE `alat`
  ADD PRIMARY KEY (`id_alat`);

--
-- Indexes for table `jadwal_perawatan_alat`
--
ALTER TABLE `jadwal_perawatan_alat`
  ADD PRIMARY KEY (`id_jadwal_perawatan`),
  ADD KEY `id_alat` (`id_alat`,`id_vendor`),
  ADD KEY `id_vendor` (`id_vendor`);

--
-- Indexes for table `vendor`
--
ALTER TABLE `vendor`
  ADD PRIMARY KEY (`id_vendor`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `alat`
--
ALTER TABLE `alat`
  MODIFY `id_alat` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `jadwal_perawatan_alat`
--
ALTER TABLE `jadwal_perawatan_alat`
  MODIFY `id_jadwal_perawatan` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `vendor`
--
ALTER TABLE `vendor`
  MODIFY `id_vendor` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `jadwal_perawatan_alat`
--
ALTER TABLE `jadwal_perawatan_alat`
  ADD CONSTRAINT `jadwal_perawatan_alat_ibfk_1` FOREIGN KEY (`id_vendor`) REFERENCES `vendor` (`id_vendor`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `jadwal_perawatan_alat_ibfk_2` FOREIGN KEY (`id_alat`) REFERENCES `alat` (`id_alat`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
