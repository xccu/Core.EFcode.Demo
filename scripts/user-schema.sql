﻿CREATE TABLE `user` (
  `USER_ID` INT(6) NOT NULL AUTO_INCREMENT,
  `USER_NAME` CHAR(50) DEFAULT NULL,
  `PASSWORD` CHAR(50) DEFAULT NULL,
  `Age` INT(6) NOT NULL,
  `Sex` CHAR(50) DEFAULT NULL,
  PRIMARY KEY (`USER_ID`)
) ENGINE=INNODB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8