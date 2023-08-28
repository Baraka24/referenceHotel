-- phpMyAdmin SQL Dump
-- version 4.1.14
-- http://www.phpmyadmin.net
--
-- Client :  127.0.0.1
-- Généré le :  Dim 31 Octobre 2021 à 04:32
-- Version du serveur :  5.6.17
-- Version de PHP :  5.5.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de données :  `bar`
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
('cat0001', 'Boisson'),
('cat002', 'Boisson');

-- --------------------------------------------------------

--
-- Structure de la table `produits`
--

CREATE TABLE IF NOT EXISTS `produits` (
  `codeproduit` varchar(50) NOT NULL,
  `nom` varchar(50) DEFAULT NULL,
  `quantite` double DEFAULT NULL,
  `prixunitaire` double DEFAULT NULL,
  `codecat` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`codeproduit`),
  KEY `codecat` (`codecat`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `produits`
--

INSERT INTO `produits` (`codeproduit`, `nom`, `quantite`, `prixunitaire`, `codecat`) VALUES
('P001', 'BOOSTER', 10, 2000, 'cat0001'),
('P002', 'Djino', 4, 1000, 'cat002');

-- --------------------------------------------------------

--
-- Structure de la table `vente`
--

CREATE TABLE IF NOT EXISTS `vente` (
  `codevente` varchar(50) NOT NULL,
  `datevente` date DEFAULT NULL,
  `quantitevendue` double DEFAULT NULL,
  `codeproduit` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`codevente`),
  KEY `codeproduit` (`codeproduit`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `vente`
--

INSERT INTO `vente` (`codevente`, `datevente`, `quantitevendue`, `codeproduit`) VALUES
('v001', '2021-10-06', 1, 'P001'),
('v003', '2021-10-05', 1, 'P001'),
('v009', '2021-10-13', 2, 'P002');

--
-- Contraintes pour les tables exportées
--

--
-- Contraintes pour la table `produits`
--
ALTER TABLE `produits`
  ADD CONSTRAINT `produits_ibfk_1` FOREIGN KEY (`codecat`) REFERENCES `categorie` (`codecat`);

--
-- Contraintes pour la table `vente`
--
ALTER TABLE `vente`
  ADD CONSTRAINT `vente_ibfk_1` FOREIGN KEY (`codeproduit`) REFERENCES `produits` (`codeproduit`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
