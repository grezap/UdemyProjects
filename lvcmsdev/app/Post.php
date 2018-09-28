<?php

namespace App;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\SoftDeletes;

class Post extends Model
{
    //
    
    private $directory = "/images/";

    Use SoftDeletes;
    
    protected $table = 'post'; // define that the database table is different than the default one
    protected $fillable = ['title','content','path'];
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

    //QueryScope: must start with word scope and after that follows the word we want to call it by
    public static function scopeLatest($query)
    {
        return $query->withTrashed()->orderBy('id','desc')->get();
    }

    public function getPathAttribute($value)
    {
        return $this->directory.$value;
    }
}
