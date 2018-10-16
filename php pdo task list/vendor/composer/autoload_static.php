<?php

// autoload_static.php @generated by Composer

namespace Composer\Autoload;

class ComposerStaticInit2b32acd0dcddb6a073ab6ff0e58889c3
{
    public static $prefixLengthsPsr4 = array (
        'v' => 
        array (
            'voku\\helper\\' => 12,
        ),
    );

    public static $prefixDirsPsr4 = array (
        'voku\\helper\\' => 
        array (
            0 => __DIR__ . '/..' . '/voku/pagination/src/voku/helper',
        ),
    );

    public static function getInitializer(ClassLoader $loader)
    {
        return \Closure::bind(function () use ($loader) {
            $loader->prefixLengthsPsr4 = ComposerStaticInit2b32acd0dcddb6a073ab6ff0e58889c3::$prefixLengthsPsr4;
            $loader->prefixDirsPsr4 = ComposerStaticInit2b32acd0dcddb6a073ab6ff0e58889c3::$prefixDirsPsr4;

        }, null, ClassLoader::class);
    }
}
