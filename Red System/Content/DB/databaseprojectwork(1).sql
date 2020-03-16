-- phpMyAdmin SQL Dump
-- version 4.9.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Creato il: Mar 16, 2020 alle 17:19
-- Versione del server: 10.4.8-MariaDB
-- Versione PHP: 7.3.11

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `databaseprojectwork`
--

-- --------------------------------------------------------

--
-- Struttura della tabella `admin`
--

CREATE TABLE `admin` (
  `ID` int(11) NOT NULL,
  `Cognome` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Nome` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Username` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Password` varchar(255) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dump dei dati per la tabella `admin`
--

INSERT INTO `admin` (`ID`, `Cognome`, `Nome`, `Username`, `Password`) VALUES
(1, 'Mascaro', 'Simone', 'SUPERCAT92', 'mastermascaro');

-- --------------------------------------------------------

--
-- Struttura della tabella `classi`
--

CREATE TABLE `classi` (
  `ID` int(11) NOT NULL,
  `Numero` int(11) NOT NULL,
  `Sezione` char(1) COLLATE utf8_unicode_ci NOT NULL,
  `Indirizzo` varchar(255) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dump dei dati per la tabella `classi`
--

INSERT INTO `classi` (`ID`, `Numero`, `Sezione`, `Indirizzo`) VALUES
(1, 5, 'c', 'informatico'),
(2, 5, 'e', 'informatico'),
(3, 5, 'g', 'relazioni');

-- --------------------------------------------------------

--
-- Struttura della tabella `domandechiuse`
--

CREATE TABLE `domandechiuse` (
  `ID` int(11) NOT NULL,
  `Domanda` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `OpzioneA` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `OpzioneB` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `OpzioneC` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `OpzioneD` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `OpzioneE` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `IDStudente` int(11) NOT NULL,
  `IDProfessore` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Struttura della tabella `professoreclasse`
--

CREATE TABLE `professoreclasse` (
  `ID` int(11) NOT NULL,
  `IDClasse` int(11) NOT NULL,
  `IDProfessore` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Struttura della tabella `user`
--

CREATE TABLE `user` (
  `ID` int(11) NOT NULL,
  `Cognome` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Nome` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `Password` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `IDClasse` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Indici per le tabelle scaricate
--

--
-- Indici per le tabelle `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`ID`);

--
-- Indici per le tabelle `classi`
--
ALTER TABLE `classi`
  ADD PRIMARY KEY (`ID`);

--
-- Indici per le tabelle `domandechiuse`
--
ALTER TABLE `domandechiuse`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `IDStudente` (`IDStudente`),
  ADD KEY `IDProfessore` (`IDProfessore`);

--
-- Indici per le tabelle `professoreclasse`
--
ALTER TABLE `professoreclasse`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `IDClasse` (`IDClasse`),
  ADD KEY `IDProfessore` (`IDProfessore`);

--
-- Indici per le tabelle `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `IDClasse` (`IDClasse`);

--
-- AUTO_INCREMENT per le tabelle scaricate
--

--
-- AUTO_INCREMENT per la tabella `admin`
--
ALTER TABLE `admin`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT per la tabella `classi`
--
ALTER TABLE `classi`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT per la tabella `domandechiuse`
--
ALTER TABLE `domandechiuse`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT per la tabella `professoreclasse`
--
ALTER TABLE `professoreclasse`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT per la tabella `user`
--
ALTER TABLE `user`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT;

--
-- Limiti per le tabelle scaricate
--

--
-- Limiti per la tabella `domandechiuse`
--
ALTER TABLE `domandechiuse`
  ADD CONSTRAINT `domandechiuse_ibfk_1` FOREIGN KEY (`IDStudente`) REFERENCES `user` (`ID`),
  ADD CONSTRAINT `domandechiuse_ibfk_2` FOREIGN KEY (`IDProfessore`) REFERENCES `admin` (`ID`);

--
-- Limiti per la tabella `professoreclasse`
--
ALTER TABLE `professoreclasse`
  ADD CONSTRAINT `professoreclasse_ibfk_1` FOREIGN KEY (`IDClasse`) REFERENCES `classi` (`ID`),
  ADD CONSTRAINT `professoreclasse_ibfk_2` FOREIGN KEY (`IDProfessore`) REFERENCES `admin` (`ID`);

--
-- Limiti per la tabella `user`
--
ALTER TABLE `user`
  ADD CONSTRAINT `user_ibfk_1` FOREIGN KEY (`IDClasse`) REFERENCES `classi` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
