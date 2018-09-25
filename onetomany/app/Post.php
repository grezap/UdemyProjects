<?php

namespace App;

use Illuminate\Database\Eloquent\Model;
/** @mixin \Eloquent */
class Post extends Model
{
    //
    protected $table = 'post';
    protected $fillable = ['title','body'];
    public function user(){
        return 1;
    }
}
