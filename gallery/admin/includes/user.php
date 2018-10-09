<?php

    class User extends dbObject {

        protected static $dbTable = 'user';
        public $idProp;
        protected static $dbTableFields = array('username','password','firstname','lastname','userimage');        
        public $user_id;
        public $username;
        public $password;
        public $firstname;
        public $lastname;
        public $userimage;
        public $imgTmpPath;
        public $uploadDir = "images";
        public $imgPlaceholder="http://placehold.it/400x400&text=image";
        public $customErrors = array();
        public $isCreated = false;
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
        

        public static function verifyUser(string $username, string $password){
            global $database;
            $username = $database->escapeString($username);
            $password = $database->escapeString($password);
            $result = self::findByQuery("select * from ".self::$dbTable." where username = '{$username}' and password = '{$password}';");
            return !empty($result) ? array_shift($result) : false;
        }

        public function getUserImage(){
            return empty($this->userimage) ? $this->imgPlaceholder : $this->uploadDir . DS . $this->userimage ;
        }

        public function setUserImage(array $file)
        {
            if (empty($file) || !$file || !is_array($file)) {
                $this->customErrors[] = "There was no file to upload or File array is not valid.";
                return false;
            }elseif ($file['error']!=0) {
                $this->customErrors[] = $this->uploadErrors[$file['error']];
                return false;
            }else {
                $this -> userimage = basename($file['name']);
                $this -> imgTmpPath = $file['tmp_name'];
            }

            return true;
        }

        public function saveUser() : bool {

            if ($this->user_id) {
                $this->update();
                $this->isCreated = true;
                //return true;
            }else {
                $this->save();
                $this->isCreated = true;
            }

            if ($this->isCreated && isset($this->userimage)) {
                $targetPath = SITE_ROOT . DS . 'admin' . DS . $this->uploadDir . DS . $this->userimage;
                if (move_uploaded_file($this->imgTmpPath, $targetPath)) {
                    unset($this->imgTmpPath);
                    return true;
                }else {
                    $this->customErrors[] = "The file details have been successfully saved in database. The file could not be uploaded.";
                    return false;
                }
            } else {
                $this->customErrors[] = "The file details could not be saved in database. The file has not been uploaded.";
                return false;
            }

            return true;

        }

        public function deleteUser() : bool
        {
            $targetPath = SITE_ROOT . DS . 'admin' . DS . $this->uploadDir . DS . $this->userimage;
            if (!isset($this->user_id)) {
                $this->customErrors[] = "User Id is empty.";
                return false;
            }
            if (file_exists($targetPath)) {
                unlink($targetPath);
            }else {
                $this->customErrors[] = "Could not delete file {$this->getUserImage()}";
                return false;
            }
            if (!$this->delete()) {
                $this->customErrors[] = "Could not delete photo from database";
                return false;
            }
            
            return true;
        }

    }
?>