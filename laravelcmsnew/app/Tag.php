<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Tag extends Model
{
    //
    protected $table = 'tag';

    public function posts()
    {
        return $this->morphedByMany('App\Post','taggable','taggable');
    }

    public function videos()
    {
        return $this->morphedByMany('App\Video','taggable','taggable');
    }
}
