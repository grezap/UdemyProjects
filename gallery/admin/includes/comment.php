<?php 

class Comment extends DbObject{
    
    protected static $dbTable = 'comment';
    protected static $dbTableFields = array('comment_photoid','comment_author','comment_body');
    public $comment_id;
    public $comment_photoid;
    public $comment_author;
    public $comment_body;

    public static function createComment($comment_photoid, $comment_author, $comment_body){
        if (!empty($comment_photoid) && !empty($comment_author) && !empty($comment_body)) {
            $comment = new Comment();
            $comment->comment_photoid = $comment_photoid;
            $comment->comment_author = $comment_author;
            $comment->comment_body = $comment_body;
            return $comment;
        }else {
            return false;
        }
    }

    public static function findCommentsByPhotoId($photo_id=0){
        global $database;
        $qry = "select * from ".self::$dbTable." where comment_photoid = " . $database->escapeString($photo_id) . " order by comment_photoid asc";
        return self::findByQuery($qry);
    }

}

?>