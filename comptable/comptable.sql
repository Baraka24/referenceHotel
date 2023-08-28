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
-- Base de données :  `comptable`
--

-- --------------------------------------------------------

--
-- Structure de la table `entree`
--

CREATE TABLE IF NOT EXISTS `entree` (
  `codeEntree` varchar(50) NOT NULL,
  `dateEntree` datetime DEFAULT NULL,
  `libelle` text,
  `codeSource` varchar(50) DEFAULT NULL,
  `montant` double DEFAULT NULL,
  PRIMARY KEY (`codeEntree`),
  KEY `codeSource` (`codeSource`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `entree`
--

INSERT INTO `entree` (`codeEntree`, `dateEntree`, `libelle`, `codeSource`, `montant`) VALUES
('1', '2021-10-06 00:00:00', 'recettes journalières', 'LaRefBar', 50000),
('2', '2021-10-31 00:00:00', 'Rapport hebdomadaire', 'LaRefLoge', 80000);

-- --------------------------------------------------------

--
-- Structure de la table `sortie`
--

CREATE TABLE IF NOT EXISTS `sortie` (
  `codeSortie` varchar(50) NOT NULL,
  `dateSortie` datetime DEFAULT NULL,
  `libelle` text,
  `beneficiaire` varchar(50) DEFAULT NULL,
  `montant` double DEFAULT NULL,
  PRIMARY KEY (`codeSortie`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `sources`
--

CREATE TABLE IF NOT EXISTS `sources` (
  `codeSource` varchar(50) NOT NULL,
  `nom` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`codeSource`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `sources`
--

INSERT INTO `sources` (`codeSource`, `nom`) VALUES
('Autres', 'Divers'),
('LaRefBar', 'Bar'),
('LaRefLoge', 'Logement'),
('LaRefRestau', 'Restaurant');

--
-- Contraintes pour les tables exportées
--

--
-- Contraintes pour la table `entree`
--
ALTER TABLE `entree`
  ADD CONSTRAINT `entree_ibfk_1` FOREIGN KEY (`codeSource`) REFERENCES `sources` (`codeSource`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
