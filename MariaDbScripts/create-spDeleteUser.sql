CREATE DEFINER=`root`@`localhost` PROCEDURE `spDeleteUser`(
	IN `idp` INT
)
LANGUAGE SQL
NOT DETERMINISTIC
CONTAINS SQL
SQL SECURITY DEFINER
COMMENT ''
BEGIN
	DELETE FROM `dbo.teusers`
	WHERE `id` = `idp`;
END