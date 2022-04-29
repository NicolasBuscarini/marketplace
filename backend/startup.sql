USE mysql;
CREATE USER 'nicolas'@'%' IDENTIFIED BY 'bob@123';
GRANT ALL ON *.* TO 'nicolas'@'%';
FLUSH PRIVILEGES;

CREATE DATABASE marketplace;

use marketplace;