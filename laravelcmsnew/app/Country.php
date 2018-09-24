<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class Country extends Model
{
    //
    protected $table = 'country';
    public function posts()
    {
        return $this->hasManyThrough('App\Post','App\User');
    }
}
