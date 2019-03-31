-- MySQL dump 10.13  Distrib 8.0.15, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: crawler-shopping
-- ------------------------------------------------------
-- Server version	8.0.15

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
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `category` (
  `category_uid` varchar(500) NOT NULL,
  `category_name` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`category_uid`),
  UNIQUE KEY `idcategory_UNIQUE` (`category_uid`),
  UNIQUE KEY `category_name_UNIQUE` (`category_name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `category`
--

LOCK TABLES `category` WRITE;
/*!40000 ALTER TABLE `category` DISABLE KEYS */;
INSERT INTO `category` VALUES ('011664ab-b8b9-4ea1-98b3-97b0e25f6f49','Camemberts, coulommiers, bries'),('24f94325-e2ab-4888-9f41-2f01898367c0','Chèvres, brebis'),('54f832e2-d75d-4ad8-ac27-258d9a658e40','Crèmes dessert'),('c820beda-eebb-46df-a75c-3e1d726d38d0','Crèmes fraîches'),('a7145081-a5e2-414a-acf2-e9dd974a537f','Crèmes U.H.T, crèmes fouettées'),('a87514f3-6415-43c2-b444-47a9f1fd053e','Cuisine, salades'),('bfc56813-71f4-46df-bc3a-0d3ff557a27f','Enfants et petits suisses'),('990cc95f-8325-4b26-8eed-86601101ff56','Fromages à la coupe'),('ce023a6e-c69e-481e-934a-7e74104f4dc4','Fromages à tartiner'),('47339815-7fca-400e-bc3c-a0ba96881c9c','Fromages allégés'),('e3ad327b-7824-414a-87e5-5526f3b066de','Fromages apéritif'),('1d17a97c-eaeb-4851-b035-4e53639b9707','Fromages du terroir'),('3887c292-0c38-4d7c-ad0d-9f8465f50791','Fromages pour enfants'),('1bfa29d2-89f8-49bd-8540-1cb5846ac2e3','Gruyère, comté, gouda et autres'),('1d1beb12-415b-47e2-8b83-c9d7463fc2bc','Margarines, matières grasses'),('161a62bf-4820-4e65-a230-18a04c1a0d27','Raclette, tartiflette, fondue'),('f566bc23-6ecf-4ead-950d-31833b24d163','Râpés gruyère, comté, parmesan'),('6a644d72-02e8-4acd-9a02-940d4e5397e2','Roqueforts, bleus'),('4ebba167-2aff-4809-9e93-65a7ebf2716f','Sandwich, burgers'),('a1485a43-dc27-471e-8854-21c2fc91948a','Sauces, aides culinaires'),('b5d83428-81b5-4195-86b3-f60669d0ae4e','Yaourts aux fruits'),('84c7525e-5dc3-4ac7-9daa-cf8dc166a42e','Yaourts gourmands'),('6d18fc48-8248-474a-a30f-2e850225aadf','Yaourts natures, fromages blancs');
/*!40000 ALTER TABLE `category` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-03-31 23:15:01
