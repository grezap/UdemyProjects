<?php

namespace App;

use Illuminate\Database\Eloquent\Model;
use Illuminate\Database\Eloquent\SoftDeletes;

class Post extends Model
{
    use SoftDeletes;
    //
    protected $table = 'post';
    protected $fillable = ['title','content'];
    protected $dates = ['deleted_at'];
    public function user()
    {
        return $this->belongsTo('App\User');
    }
}
