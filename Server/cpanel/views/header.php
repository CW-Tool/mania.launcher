<!DOCTYPE html>
<html>
<head>
	<title>WowSuite CPanel</title>
	<link rel="stylesheet" href="<?php echo URL; ?>public/css/default.css" />
	<link rel="stylesheet" href="<?php echo URL; ?>public/css/zozo.style.min.css" />
	<link rel="stylesheet" href="<?php echo URL; ?>public/css/zozo.tabs.min.css" />
	<script type="text/javascript" src="<?php echo URL; ?>public/js/jquery.tabs.min.js"></script>
	<script type="text/javascript" src="<?php echo URL; ?>public/js/zozo.tabs.min.js"></script>
	<script type="text/javascript" src="<?php echo URL; ?>public/js/custom.js"></script>
	
	<?php
		if (isset($this->js)) 
		{
			foreach ($this->js as $js)
			{
				echo '<script type="text/javascript" src="'.URL.'views/'.$js.'"></script>';
			}
		}
	?>
</head>
<body>

<?php Session::init(); ?>
	
	
<div id="header">

	<?php if (Session::get('loggedIn') == false):?>
	<!-- <a href="<?php echo URL; ?>login">Login</a> -->
	
	<?php endif; ?>
	<?php if (Session::get('loggedIn') == true):?>
	<a href="<?php echo URL; ?>dashboard">Dashboard</a>
	<?php if (Session::get('role') == 'admin'):?>
	<a href="<?php echo URL; ?>user">Users</a>
	<!--<a href="<?php echo URL; ?>patchlist">Patchlist Editor</a> -->
	<?php endif; ?>
<a href="<?php echo URL; ?>help">Help</a>
	<a href="<?php echo URL; ?>dashboard/logout">Logout</a>	


	<?php endif; ?>
</div>

<div id="content">