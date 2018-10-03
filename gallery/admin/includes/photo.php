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

        public $tmp_path;
        public $imgDir= "images";
        public $customErrors = array();
        public $uploadErrors = array(
            UPLOAD_ERR_OK => "There is no error",
            UPLOAD_ERR_INI_SIZE => "The uploaded file exceeds the upload_max_filesize directive in php.ini",
            UPLOAD_ERR_FORM_SIZE => "The uploaded file exceeds the MAX_FILE_SIZE directive that was specified in the HTML form",
            UPLOAD_ERR_PARTIAL => "The uploaded file was only partially uploaded",
            UPLOAD_ERR_NO_FILE => "No file was uploaded",
            UPLOAD_ERR_NO_TMP_DIR => "Missing a temporary folder",
            UPLOAD_ERR_CANT_WRITE => "Failed to write file to disk",
            UPLOAD_ERR_EXTENSION => "A PHP Extension stopped the file upload"
        );

    }
    
?>