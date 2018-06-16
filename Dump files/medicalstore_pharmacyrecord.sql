-- MySQL dump 10.13  Distrib 8.0.11, for Win64 (x86_64)
--
-- Host: localhost    Database: medicalstore
-- ------------------------------------------------------
-- Server version	8.0.11

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `pharmacyrecord`
--

DROP TABLE IF EXISTS `pharmacyrecord`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `pharmacyrecord` (
  `sn` int(11) NOT NULL AUTO_INCREMENT,
  `productname` varchar(45) DEFAULT NULL,
  `quantity` varchar(45) DEFAULT NULL,
  `rate` varchar(45) DEFAULT NULL,
  `expirydate` varchar(45) DEFAULT NULL,
  `recordedon` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`sn`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pharmacyrecord`
--

LOCK TABLES `pharmacyrecord` WRITE;
/*!40000 ALTER TABLE `pharmacyrecord` DISABLE KEYS */;
INSERT INTO `pharmacyrecord` VALUES (6,'cetamol','160','50','2025-01-12','2018-02-04'),(7,'vitamin','30','200','2023-01-25','2018-01-22'),(8,'honitus','100','200','2025-12-31','2018-05-19'),(9,'Cold cream','100','350','2025-01-18','2018-01-22'),(10,'chyawanprash','50','600','2020-01-18','2018-02-02'),(11,'Horlicks','50','750','2010-01-20','2018-01-22'),(12,'honey','40','300','2019-01-20','2018-01-31'),(13,'Vicks','500','50','2020-01-18','2018-01-22'),(14,'xanax','50','500','2015-02-02','2018-02-02'),(15,'Eno','1000','10','2024-05-19','2018-05-19'),(17,'vitamin A','500','20','2010-05-19','2018-05-19'),(18,'vitamin B','200','150','2010-07-19','2018-05-19');
/*!40000 ALTER TABLE `pharmacyrecord` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-05-19 10:21:41
