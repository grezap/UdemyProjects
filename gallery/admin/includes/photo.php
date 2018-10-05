<?php
    class Photo extends dbObject
    {
        #region properties

        protected static $dbTable = 'photo';
        protected static $dbTableFields = array('photo_title','photo_description','photo_filename','photo_type','photo_size','photo_caption','photo_alternatetext');    
        private $isCreated = false;    
        public $photo_id;
        public $photo_title;
        public $photo_description;
        public $photo_filename;
        public $photo_type;
        public $photo_size;
        public $photo_alternatetext;
        public $photo_caption;

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

        #endregion
        
        #region methods

        public function setFile(array $file) : bool{

            if (empty($file) || !$file || !is_array($file)) {
                $this->customErrors[] = "There was no file to upload or File array is not valid.";
                return false;
            }elseif ($file['error']!=0) {
                $this->customErrors[] = $this->uploadErrors[$file['error']];
                return false;
            }else {
                $this -> photo_filename = basename($file['name']);
                $this -> tmp_path = $file['tmp_name'];
                $this -> photo_type = $file['type'];
                $this -> photo_size = $file['size']; 
                
            }

            return true;

        }

        public function savePhoto() : bool {
            
            if (empty($this->photo_filename) || empty($this->tmp_path)) {
                $this->customErrors[] = "The file name or tmp path were not filled correctly.";
                return false;
            }

            if (!empty($this->customErrors)) {
                return false;
            }
            
            if ($this->photo_id) {
                $this -> update();
                return true;
            } else {
                $this->create();
                $this->isCreated = true;
            }

            $targetPath = SITE_ROOT . DS . 'admin' . DS . $this->imgDir . DS . $this->photo_filename;
            
            if (file_exists($targetPath)) {
                $this->customErrors[] = "The file with name : {$this->photo_filename} already exists";
                return false;
            }

            if ($this->isCreated) {
                if (move_uploaded_file($this->tmp_path, $targetPath)) {
                    unset($this->tmp_path);
                    return true;
                }else {
                    $this->customErrors[] = "The file details have been successfully saved in database. The file could not be uploaded.";
                    return false;
                }
            }
            else {
                $this->customErrors[] = "The file details could not be saved in database. The file has not been uploaded.";
                return false;
            }

            return true;
        }

        public function picturePath(){
            return $this->imgDir.DS.$this->photo_filename;
        }

        public function deletePhoto() : bool{
            if (!isset($this->photo_id)) {
                $this->customErrors[] = "Photo Id is empty.";
                return false;
            }

            $targetPath = SITE_ROOT.DS."admin".DS.$this->picturePath();

            if (file_exists($targetPath)) {
                unlink($targetPath);
            }else {
                $this->customErrors[] = "Could not delete file {$this->picturePath()}";
                return false;
            }

            if (!$this->delete()) {
                $this->customErrors[] = "Could not delete photo from database";
                return false;
            }
            
            return true;
        }

        #endregion

    }
    
?>