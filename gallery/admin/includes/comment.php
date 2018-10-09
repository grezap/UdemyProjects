<?php 

class Comment extends DbObject{
    
    protected static $dbTable = 'comment';
    protected static $dbTableFields = array('comment_photoid','comment_author','comment_body');
    public $comment_id;
    public $comment_photoid;
    public $comment_author;
    public $comment_body;

    

}

?>