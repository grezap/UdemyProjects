<?php
    class Photo extends dbObject
    {
        protected static $dbTable = 'photo';
        protected static $dbTableFields = array('photo_title','photo_description','photo_filename','photo_type','photo_size');        
        public $photo_id;
        public $photo_title;
        public $photo_description;
        public $photo_filename;
        public $photo_type;
        public $photo_size;

        
    }
    
?>