CREATE DEFINER=`root`@`localhost` PROCEDURE `spGetSingleUser`(
	IN `id` INT
)
LANGUAGE SQL
NOT DETERMINISTIC
CONTAINS SQL
SQL SECURITY DEFINER
COMMENT ''
BEGIN
	SELECT *
	FROM `dbo.teusers` a
	WHERE a.id = `id`;
END