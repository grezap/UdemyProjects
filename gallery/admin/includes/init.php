<?php 

    defined('DS') ? null : define('DS', DIRECTORY_SEPARATOR);

    defined('SITE_ROOT') ? null : define('SITE_ROOT', "c:" . DS . "_Dev_" . DS . "_Github_Repos_" . DS . "UdemyProjects" . DS . "gallery") ;

    defined('INCLUDES_PATH') ? null : define('INCLUDES_PATH', SITE_ROOT . DS . "admin" . DS . "includes" );

    // c:/_Dev_/_Github_Repos_/UdemyProjects/gallery
    require_once("functions.php");    
    require_once("new_config.php");
    require_once("database.php");
    require_once("dbObject.php");
    require_once("user.php");
    require_once("photo.php");
    require_once("session.php");
?>