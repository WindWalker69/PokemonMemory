-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: pokemonmemoryrank
-- ------------------------------------------------------
-- Server version	8.0.19

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `easy_rank`
--

DROP TABLE IF EXISTS `easy_rank`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `easy_rank` (
  `id_easy_rank` int NOT NULL AUTO_INCREMENT,
  `name` varchar(60) NOT NULL,
  `best_time` time(3) NOT NULL,
  `best_score` int NOT NULL,
  PRIMARY KEY (`id_easy_rank`),
  UNIQUE KEY `idEasyRank_UNIQUE` (`id_easy_rank`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `easy_rank`
--

LOCK TABLES `easy_rank` WRITE;
/*!40000 ALTER TABLE `easy_rank` DISABLE KEYS */;
INSERT INTO `easy_rank` VALUES (1,'MARIO','00:00:09.274',540),(2,'LUCA','00:00:15.404',460),(3,'FRA','00:00:14.281',560);
/*!40000 ALTER TABLE `easy_rank` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hard_rank`
--

DROP TABLE IF EXISTS `hard_rank`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `hard_rank` (
  `id_hard_rank` int NOT NULL AUTO_INCREMENT,
  `name` varchar(60) NOT NULL,
  `best_time` time(3) NOT NULL,
  `best_score` int NOT NULL,
  PRIMARY KEY (`id_hard_rank`),
  UNIQUE KEY `idHardRank_UNIQUE` (`id_hard_rank`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hard_rank`
--

LOCK TABLES `hard_rank` WRITE;
/*!40000 ALTER TABLE `hard_rank` DISABLE KEYS */;
INSERT INTO `hard_rank` VALUES (1,'TOMMY','00:01:25.893',630),(2,'PEPPE','00:01:43.112',410),(3,'FIRHAAN','00:01:58.789',680),(4,'MARIO','00:00:50.380',1080);
/*!40000 ALTER TABLE `hard_rank` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `normal_rank`
--

DROP TABLE IF EXISTS `normal_rank`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `normal_rank` (
  `id_normal_rank` int NOT NULL AUTO_INCREMENT,
  `name` varchar(60) NOT NULL,
  `best_time` time(3) NOT NULL,
  `best_score` int NOT NULL,
  PRIMARY KEY (`id_normal_rank`),
  UNIQUE KEY `idNormalRank_UNIQUE` (`id_normal_rank`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `normal_rank`
--

LOCK TABLES `normal_rank` WRITE;
/*!40000 ALTER TABLE `normal_rank` DISABLE KEYS */;
INSERT INTO `normal_rank` VALUES (4,'MARIO','00:00:26.505',740),(5,'SARA','00:00:44.735',760),(6,'GABRI','00:00:29.417',780);
/*!40000 ALTER TABLE `normal_rank` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_scores`
--

DROP TABLE IF EXISTS `user_scores`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `user_scores` (
  `id_score` int NOT NULL AUTO_INCREMENT,
  `id_user` int NOT NULL,
  `time` time(3) NOT NULL,
  `score` int NOT NULL,
  `difficult` varchar(10) NOT NULL,
  PRIMARY KEY (`id_score`),
  UNIQUE KEY `idUserScores_UNIQUE` (`id_score`),
  KEY `fk_userScores_user_idx` (`id_user`),
  CONSTRAINT `fk_userScores_user` FOREIGN KEY (`id_user`) REFERENCES `users` (`id_user`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_scores`
--

LOCK TABLES `user_scores` WRITE;
/*!40000 ALTER TABLE `user_scores` DISABLE KEYS */;
INSERT INTO `user_scores` VALUES (1,1,'00:00:13.142',470,'EASY'),(2,1,'00:00:09.934',520,'EASY'),(3,1,'00:00:15.424',470,'EASY'),(4,1,'00:00:10.274',530,'EASY'),(5,1,'00:00:09.274',540,'EASY'),(6,1,'00:00:26.505',700,'NORMAL'),(7,2,'00:00:15.404',460,'EASY'),(8,3,'00:00:44.735',760,'NORMAL'),(9,4,'00:00:29.417',780,'NORMAL'),(10,5,'00:01:25.893',630,'HARD'),(11,6,'00:01:43.112',410,'HARD'),(12,7,'00:01:58.789',680,'HARD'),(13,1,'00:00:29.128',740,'NORMAL'),(14,1,'00:00:47.595',490,'NORMAL'),(15,1,'00:00:54.949',380,'NORMAL'),(16,1,'00:00:44.161',590,'NORMAL'),(17,1,'00:00:46.771',560,'NORMAL'),(18,1,'00:00:42.201',550,'NORMAL'),(19,3,'00:00:51.262',470,'NORMAL'),(20,4,'00:00:37.387',620,'NORMAL'),(21,8,'00:00:14.281',560,'EASY'),(22,1,'00:00:50.380',1080,'HARD'),(23,1,'00:01:06.181',850,'HARD'),(24,1,'00:01:29.556',580,'HARD');
/*!40000 ALTER TABLE `user_scores` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `id_user` int NOT NULL AUTO_INCREMENT,
  `name` varchar(60) NOT NULL,
  PRIMARY KEY (`id_user`),
  UNIQUE KEY `idUser_UNIQUE` (`id_user`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'MARIO'),(2,'LUCA'),(3,'SARA'),(4,'GABRI'),(5,'TOMMY'),(6,'PEPPE'),(7,'FIRHAAN'),(8,'FRA');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-04-21  8:49:50
