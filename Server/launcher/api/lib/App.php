<?php

class App {

    public static $key;
    private static $_conf = false;
    protected static $_init;
    const PATH = ROOT;

    public static function __Init(){
        $key = isset($_GET['_key']) ? $_GET['_key'] : false;

        if(self::$key !== $key){
            header('HTTP/1.1 404 Not Found');
            header('Status: 404 Not Found');
            exit();
        }

        if(self::$_init === null){
            self::$_init = new self();
        }
        return self::$_init;
    }

    protected function __construct(){
        $file = self::PATH.'api'.DS.'config.php';
        if(is_file($file)){
            self::$_conf = require_once $file;
        }else{
            $this->error('Not Found File config!',E_USER_ERROR);
        }
    }

    private function error($msg,$type){
        if(DISPLAY_ERROR === true){
            trigger_error($msg,$type);
        }
        exit();
    }

    private function TestConnect($host,$port){
        $fp = @fsockopen($host, $port, $errno, $errstr, 10);
        if($fp){
            return true;
        }else{
            return false;
        }
    }

    protected function Connect($db){
       if($this->TestConnect(self::$_conf['host'],self::$_conf['port'])) {
           return new \medoo(array(
                   'database_type' => 'mysql',
                   'database_name' => $db,
                   'server' => self::$_conf['host'],
                   'username' => self::$_conf['user'],
                   'password' => self::$_conf['pass'],
                   'charset' => 'utf8',
                   'port' => self::$_conf['port'],
                   'option' => array(
                       \PDO::ATTR_CASE => \PDO::CASE_NATURAL
                   ))
           );
       }else{
           exit();
       }
    }

    protected function XMLRender($keys,$data,$multi = false){
        if(is_array($keys) and is_array($data)) {

            //header("Content-Type: text/xml");

            $xml = new XMLWriter();
            $xml->openMemory();
            $xml->startDocument();

            if($multi === false) {
                foreach ($keys as $key) {
                    $xml->startElement($key);
                }

                foreach ($data as $key => $val) {
                    $xml->writeElement($key, $val);
                }

                foreach ($keys as $key) {
                    $xml->endElement();
                }
            }else{
                $elem = array_pop($keys);

                foreach ($keys as $key) {
                    $xml->startElement($key);
                }

                foreach($data as $line){
                    $xml->startElement($elem);
                    foreach($line as $k=>$l){
                        $xml->writeElement($k, $l);
                    }
                    $xml->endElement();
                }

                foreach ($keys as $key) {
                    $xml->endElement();
                }
            }

           return $xml->outputMemory();
        }else{
            $this->error('XML Data ERROR',E_USER_ERROR);
        }
    }
    public function getOnline(){
        $db = $this->Connect(self::$_conf['characters']);
        $online = '';
        $online_list = $db->query("SELECT name,race,class,level,gender FROM `characters` WHERE `online` = 1 AND NOT `extra_flags` & 16 ORDER BY `name`")->fetchAll();
        if($online_list !== false and count($online_list) > 0){
            foreach($online_list as $key=>$onl){
                $class = $this->ClassState($onl['class']);
                $online[$key] = array(
                    'Name'=>$onl['name'],
                    'Level'=>$onl['level'],
                    'Race'=>self::$_conf['site_url'].$this->OnlineIcon((int) $onl['race'],(int) $onl['gender']),
                    'Class'=>$class['class'],
                    'Side'=>$this->Fraction((int) $onl['race']),
                    'TotalTime'=>$this->totalTime($onl['totaltime'])
                );
            }
            if(is_array($online)){
                echo $this->XMLRender(array('Characters','Stat','CharBlock'),$online,true);
            }else{
                echo 0;
            }

        }else{
            echo 0;
        }
    }

    public function getHotNews(){
        $db = $this->Connect(self::$_conf['news']);
        $hot_news = $db->select('hot_news','*' ,array('realms'=>'realm1', 'LIMIT'=>1));
	        if($hot_news !== false and count($hot_news) > 0 and $hot_news[0]['message'] != ''){
            echo $hot_news[0]['message'];
        }else{
            echo 'note';
        }
    }

    public function getNews(){
        $db = $this->Connect(self::$_conf['news']);
        $new = '';
        $news = $db->select('news_launcher','*' ,array('realms'=>'realm1', 'ORDER'=>'id DESC','LIMIT'=>4));
        if($news != false and count($news) > 0){
            foreach($news as $key=>$new_post){
                $new[$key] = array(
                    'NewsTitle'=>$new_post['title'],
                    'Text'=>$new_post['message'],
                    'ImageLink'=>$new_post['imagelink'],
                    'NewsLink'=>$new_post['newslink'],
                );
            }
            if(is_array($new)){
                echo $this->XMLRender(array('NewsRoot','ExpressNews','NewsItem'),$new,true);
            }else{
                echo $this->XMLRender(array('NewsRoot','ExpressNews','NewsItem'),array('NewsTitle'=>'No news !'));
            }
        }else{
            echo $this->XMLRender(array('NewsRoot','ExpressNews','NewsItem'),array('NewsTitle'=>'No news !'));
        }
    }

	///  COUNT ONLINE     ///
	public function CountOnline(){
        $db = $this->Connect(self::$_conf['characters']);
        $online = $db->count('characters',array('online'=>1));
        if(is_numeric($online) and $online !== 0){
            echo $online;
        }else{
            echo 0;
        }
    }
	
	//////// LOGIN  //////////
	function hashPass($login,$pass){
	return sha1(strtoupper($login).':'.strtoupper($pass));
	}
	public function getLogin(){
		$login = $_GET['login'];
		$pass = $_GET['password'];
		$db = $this->Connect(self::$_conf['auth']);
		$user = $db->select('account', '*', array('AND' => array('username' => $login, 'sha_pass_hash' => $this->hashPass($login, $pass))));
		sleep(1); // пауза
		if (is_array($user) and count($user) > 0) {
		echo 'true';
		} else {
		echo 'false';
		}
		
	}

	public function getNewsTab(){
        $db = $this->Connect(self::$_conf['news']);
        $new = '';
        //$news = $db->select('news_launcher','*',array('ORDER'=>'id DESC','LIMIT'=>20));
		$news = $db->select('news_launcher','*',array('ORDER'=>'id DESC'));
        if($news != false and count($news) > 0){
            foreach($news as $key=>$new_post){
                $new[$key] = array(
                    'NewsTitle'=>$new_post['title'],
                    'Text'=>$new_post['message'],
                    'ImageLink'=>$new_post['imagelink'],
                    'NewsLink'=>$new_post['newslink'],
					'Realms'=>$new_post['realms'],
					'Date'=>$new_post['date_time'],
                );
            }
            if(is_array($new)){
                echo $this->XMLRender(array('NewsRoot','ExpressNews','NewsItem'),$new,true);
            }else{
                echo $this->XMLRender(array('NewsRoot','ExpressNews','NewsItem'),array('NewsTitle'=>'No news !'));
            }
        }else{
            echo $this->XMLRender(array('NewsRoot','ExpressNews','NewsItem'),array('NewsTitle'=>'No news !'));
        }
    }	
}