CREATE USER 'nicols'@'%' IDENTIFIED BY 'bob@123';
GRANT ALL PRIVILEGES ON *.* TO 'nicols'@'%' WITH GRANT OPTION;

CREATE DATABASE marketplace;