CREATE TABLE `dbo.teusers` (
	`id` MEDIUMINT(9) NOT NULL AUTO_INCREMENT,
	`firstname` CHAR(100) NOT NULL COLLATE 'latin2_general_ci',
	`lastname` CHAR(100) NOT NULL COLLATE 'latin2_general_ci',
	`age` INT(11) NOT NULL,
	`city` CHAR(50) NOT NULL COLLATE 'latin2_general_ci',
	`timecreated` DATETIME NOT NULL,
	PRIMARY KEY (`id`) USING BTREE
)
COLLATE='latin2_general_ci'
ENGINE=InnoDB
;
