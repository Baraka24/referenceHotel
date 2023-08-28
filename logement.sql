-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Client :  127.0.0.1
-- Généré le :  Lun 01 Novembre 2021 à 14:11
-- Version du serveur :  5.6.17
-- Version de PHP :  5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de données :  `logement`
--

-- --------------------------------------------------------

--
-- Structure de la table `categorie`
--

CREATE TABLE IF NOT EXISTS `categorie` (
  `codecat` varchar(50) NOT NULL,
  `nom` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`codecat`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `categorie`
--

INSERT INTO `categorie` (`codecat`, `nom`) VALUES
('Cat004', 'Chambre Ordinaire'),
('Cat007', 'Chambre Vip'),
('CATV', 'VIPa');

-- --------------------------------------------------------

--
-- Structure de la table `chambre`
--

CREATE TABLE IF NOT EXISTS `chambre` (
  `numero` int(11) NOT NULL,
  `nom` varchar(50) DEFAULT NULL,
  `prix` double DEFAULT NULL,
  `codecat` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`numero`),
  KEY `codecat` (`codecat`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `chambre`
--

INSERT INTO `chambre` (`numero`, `nom`, `prix`, `codecat`) VALUES
(1, 'xx', 5, 'Cat004'),
(2, 'hh', 10, 'Cat007'),
(3, 'tt', 10, 'Cat004');

-- --------------------------------------------------------

--
-- Structure de la table `reservation`
--

CREATE TABLE IF NOT EXISTS `reservation` (
  `codeReservation` varchar(50) NOT NULL,
  `dateReservation` date DEFAULT NULL,
  `numero` int(11) DEFAULT NULL,
  `duree` varchar(10) NOT NULL,
  PRIMARY KEY (`codeReservation`),
  KEY `numero` (`numero`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `reservation`
--

INSERT INTO `reservation` (`codeReservation`, `dateReservation`, `numero`, `duree`) VALUES
('hk', '2021-10-30', 1, '2j'),
('r002', '2021-10-05', 1, '2h'),
('r004', '2021-10-27', 2, '1jr'),
('r20', '2021-10-30', 1, '2'),
('r85', '2021-10-06', 2, '8'),
('ss', '2021-10-30', 1, 'sz');

--
-- Contraintes pour les tables exportées
--

--
-- Contraintes pour la table `chambre`
--
ALTER TABLE `chambre`
  ADD CONSTRAINT `chambre_ibfk_1` FOREIGN KEY (`codecat`) REFERENCES `categorie` (`codecat`);

--
-- Contraintes pour la table `reservation`
--
ALTER TABLE `reservation`
  ADD CONSTRAINT `reservation_ibfk_1` FOREIGN KEY (`numero`) REFERENCES `chambre` (`numero`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
