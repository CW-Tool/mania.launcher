<?php

define('URL', 'http://127.0.0.1/cpanel/');
define('LIBS', 'libs/');

define('DB_TYPE', 'mysql');
define('DB_HOST', 'localhost');
define('DB_NAME', 'mania');
define('DB_USER', 'root');  // СЮДА ЛОГИН
define('DB_PASS', 'root'); // СЮДА ПАРОЛЬ

// The sitewide hashkey, do not chaneg this because its used for passwords!
// This is for other hash keys... Not sure yet
define('HASH_GENERAL_KEY', 'MixitUp200');

// This is for database passwords only.
define('HASH_PASSWORD_KEY', 'catsFLYhigh@200miles');
?>