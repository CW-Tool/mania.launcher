<?php


//if (version_compare(PHP_VERSION, '5.4.0') < 0) {
if (version_compare(PHP_VERSION, '5.3.0') < 0) {
    die('[My PHP version('.PHP_VERSION.')] << [APP PHP version(5.4.0)]');
}

require_once ROOT.'api'.DS.'Autoload.php';

Autoload::register(ROOT);

$get = isset($_GET['_url']) ? $_GET['_url'] : false;

\App::$key = 'ffc312f882fbeeb51504483ee8c691a2';

$api = \App::__Init();

if($get === 'online'){
    $api->getOnline();	
}
elseif($get === 'news'){
    $api->getNews();
}
elseif($get === 'hot_news') {
    $api->getHotNews();
}
elseif($get === 'count_online'){
    $api->CountOnline();
}
elseif($get === 'getNewsTab'){
    $api->getNewsTab();
}
elseif($get === 'auth'){
    $api->getLogin();
	

}else{
    header('HTTP/1.1 404 Not Found');
    header('Status: 404 Not Found');
    exit();
}



