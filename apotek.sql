-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 14, 2023 at 02:37 AM
-- Server version: 10.4.27-MariaDB
-- PHP Version: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `apotek`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbl_log`
--

CREATE TABLE `tbl_log` (
  `id_log` int(11) NOT NULL,
  `waktu` datetime NOT NULL,
  `aktifitas` varchar(50) NOT NULL,
  `id_user` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_log`
--

INSERT INTO `tbl_log` (`id_log`, `waktu`, `aktifitas`, `id_user`) VALUES
(1, '2023-04-13 07:39:46', 'Login', 3),
(2, '2023-04-13 07:41:44', 'Batal', 0),
(3, '2023-04-13 07:46:25', 'Batal', 0),
(4, '2023-04-13 07:46:27', 'Batal', 0),
(5, '2023-04-13 07:48:42', 'Batal', 1),
(6, '2023-04-13 00:00:00', 'Login', 1),
(7, '2023-04-13 00:00:00', 'Login', 8),
(8, '2023-04-13 00:00:00', 'Login', 9),
(9, '2023-04-13 00:00:00', 'Login', 1),
(10, '2023-04-13 00:00:00', 'Login', 8),
(11, '2023-04-13 00:00:00', 'Login', 9),
(12, '2023-04-13 00:00:00', 'Login', 9),
(13, '2023-04-13 00:00:00', 'Login', 9),
(14, '2023-04-13 00:00:00', 'Login', 1),
(15, '2023-04-14 00:00:00', 'Login', 1);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_obat`
--

CREATE TABLE `tbl_obat` (
  `id_obat` int(11) NOT NULL,
  `kode_obat` varchar(50) NOT NULL,
  `nama_obat` varchar(50) NOT NULL,
  `expired_date` varchar(50) NOT NULL,
  `jumlah` bigint(20) NOT NULL,
  `harga` bigint(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_obat`
--

INSERT INTO `tbl_obat` (`id_obat`, `kode_obat`, `nama_obat`, `expired_date`, `jumlah`, `harga`) VALUES
(1, 'K001', 'ayam', '06/04/2023', 5, 7000),
(3, 'K002', 'bodrexin', '11/04/2023', 45, 1000),
(4, 'K003', 'paramek', '29/04/2023', 15, 2000);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_ptransaksi`
--

CREATE TABLE `tbl_ptransaksi` (
  `id_ptransaksi` int(11) NOT NULL,
  `type_resep` varchar(11) NOT NULL,
  `no_resep` varchar(11) NOT NULL,
  `tgl_resep` varchar(50) NOT NULL,
  `nama_pasien` varchar(50) NOT NULL,
  `nama_dokter` varchar(50) NOT NULL,
  `nama_obat` varchar(50) NOT NULL,
  `harga` bigint(20) NOT NULL,
  `quantity` int(11) NOT NULL,
  `no_transaksi` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_ptransaksi`
--

INSERT INTO `tbl_ptransaksi` (`id_ptransaksi`, `type_resep`, `no_resep`, `tgl_resep`, `nama_pasien`, `nama_dokter`, `nama_obat`, `harga`, `quantity`, `no_transaksi`) VALUES
(46, 'Pilih Type', 'R001', '13/04/2023', 'jelang ', 'gatot', 'bodrexin', 1000, 5, '14040001');

--
-- Triggers `tbl_ptransaksi`
--
DELIMITER $$
CREATE TRIGGER `obat_keluar` AFTER INSERT ON `tbl_ptransaksi` FOR EACH ROW BEGIN
	UPDATE tbl_obat SET jumlah= jumlah - NEW.quantity
    WHERE nama_obat = NEW.nama_obat;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_resep`
--

CREATE TABLE `tbl_resep` (
  `id_resep` int(11) NOT NULL,
  `no_resep` varchar(50) NOT NULL,
  `tgl_resep` date NOT NULL,
  `nama_pasien` varchar(50) NOT NULL,
  `nama_dokter` varchar(50) NOT NULL,
  `obat_dibeli` varchar(50) NOT NULL,
  `jumlah_obatresep` bigint(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_resep`
--

INSERT INTO `tbl_resep` (`id_resep`, `no_resep`, `tgl_resep`, `nama_pasien`, `nama_dokter`, `obat_dibeli`, `jumlah_obatresep`) VALUES
(1, 'R001', '2023-04-13', 'jelang ', 'gatot', 'bodrexin', 5),
(2, 'R002', '2023-04-14', 'sakip', 'eva sulis', 'paramek', 2);

-- --------------------------------------------------------

--
-- Table structure for table `tbl_transaksi`
--

CREATE TABLE `tbl_transaksi` (
  `id_transaksi` int(11) NOT NULL,
  `no_transaksi` varchar(50) NOT NULL,
  `tgl_transaksi` date NOT NULL,
  `nama_kasir` varchar(50) NOT NULL,
  `total_bayar` bigint(20) NOT NULL,
  `id_user` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_user`
--

CREATE TABLE `tbl_user` (
  `id_user` int(11) NOT NULL,
  `type_user` varchar(11) NOT NULL,
  `nama_user` varchar(50) NOT NULL,
  `alamat` varchar(150) NOT NULL,
  `telpon` varchar(50) NOT NULL,
  `username` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_user`
--

INSERT INTO `tbl_user` (`id_user`, `type_user`, `nama_user`, `alamat`, `telpon`, `username`, `password`) VALUES
(1, 'Admin', 'jelang', 'bandung', '01111', 'jelangA123', 'jelangkode'),
(8, 'Apoteker', 'asep', 'bandung', '0858333222', 'asep123', 'asepkode'),
(9, 'Kasir', 'ari', 'sukabumi', '0858222333', 'ari123', 'arikode');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tbl_log`
--
ALTER TABLE `tbl_log`
  ADD PRIMARY KEY (`id_log`),
  ADD KEY `id_user` (`id_user`);

--
-- Indexes for table `tbl_obat`
--
ALTER TABLE `tbl_obat`
  ADD PRIMARY KEY (`id_obat`);

--
-- Indexes for table `tbl_ptransaksi`
--
ALTER TABLE `tbl_ptransaksi`
  ADD PRIMARY KEY (`id_ptransaksi`);

--
-- Indexes for table `tbl_resep`
--
ALTER TABLE `tbl_resep`
  ADD PRIMARY KEY (`id_resep`);

--
-- Indexes for table `tbl_transaksi`
--
ALTER TABLE `tbl_transaksi`
  ADD PRIMARY KEY (`id_transaksi`),
  ADD KEY `id_user` (`id_user`);

--
-- Indexes for table `tbl_user`
--
ALTER TABLE `tbl_user`
  ADD PRIMARY KEY (`id_user`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tbl_log`
--
ALTER TABLE `tbl_log`
  MODIFY `id_log` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `tbl_obat`
--
ALTER TABLE `tbl_obat`
  MODIFY `id_obat` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `tbl_ptransaksi`
--
ALTER TABLE `tbl_ptransaksi`
  MODIFY `id_ptransaksi` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=47;

--
-- AUTO_INCREMENT for table `tbl_resep`
--
ALTER TABLE `tbl_resep`
  MODIFY `id_resep` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `tbl_transaksi`
--
ALTER TABLE `tbl_transaksi`
  MODIFY `id_transaksi` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `tbl_user`
--
ALTER TABLE `tbl_user`
  MODIFY `id_user` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
