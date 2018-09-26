<?php

namespace App;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\SoftDeletes;

class Post extends Model
{
    //
    
    Use SoftDeletes;
    
    protected $table = 'post'; // define that the database table is different than the default one
    protected $fillable = ['title','content'];
    protected $dates = ['deleted_at'];
    public function user()
    {
        return $this->belongsTo('App\User');
    }
    public function photos()
    {
        return $this->morphMany('App\Photo','imageable');
    }

    public function tags()
    {
       return $this->morphToMany('App\Tag','taggable','taggable');
    }
}
