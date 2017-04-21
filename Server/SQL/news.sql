
CREATE TABLE IF NOT EXISTS `news_launcher` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(255) NOT NULL,
  `message` varchar(10000) NOT NULL,
  `newslink` varchar(255) NOT NULL,
  `imagelink` varchar(255) NOT NULL,
  `realms` varchar(255) NOT NULL,
  `date_time` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 ;

INSERT INTO `news_launcher` (`id`, `title`, `message`, `newslink`, `imagelink`, `realms`, `date_time`) VALUES
(1, 'Новый комикс: «Сумерки в Сурамаре»', 'Автор, Мэтт Бернс (Matt Burns) — старший сценарист Blizzard Entertainment и соавтор, в частности, «Хроник Варкрафт». Художник Людо Луллаби (Ludo Lullabi) выпустил более двадцати альбомов и неоднократно работал с Blizzard, в том числе над комиксами по мотивам World of Warcraft.', 'http://127.0.0.1/', 'http://127.0.0.1/launcher/1.jpg', 'realm1', '13 October 2016');


CREATE TABLE IF NOT EXISTS `hot_news` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `message` text,
  `realms` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

INSERT INTO `hot_news` (`id`, `message`, `realms`) VALUES
(1, 'Новый комикс: «Сумерки в Сурамаре»', 'realm1');


CREATE TABLE IF NOT EXISTS `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `realname` varchar(128) DEFAULT NULL,
  `username` varchar(45) NOT NULL,
  `password` varchar(64) NOT NULL,
  `email` varchar(128) NOT NULL,
  `role` enum('default','admin') NOT NULL DEFAULT 'admin',
  PRIMARY KEY (`id`),
  UNIQUE KEY `username_UNIQUE` (`username`),
  UNIQUE KEY `email` (`email`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=3 ;

INSERT INTO `users` (`id`, `realname`, `username`, `password`, `email`, `role`) VALUES
(1, 'Nostale', 'admin', '3f5cbfff0a2c6d067e53a582f08799652e24b446c50fedaee28e335d7f1a8527', 'admin@admin.ru', 'admin'),
