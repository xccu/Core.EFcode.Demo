﻿CREATE TABLE `user` (
  `ID` int(6) NOT NULL AUTO_INCREMENT,
  `NAME` char(50) DEFAULT NULL,
  `PASSWORD` char(50) DEFAULT NULL,
  `Age` int(6) NOT NULL,
  `Sex` char(50) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8