<?php $__env->startSection('content'); ?>
    <h1>Post Page</h1>
    <?php echo e($id); ?> <?php echo e($name); ?>

<?php $__env->stopSection(); ?>

<?php echo $__env->make('layouts.app', array_except(get_defined_vars(), array('__data', '__path')))->render(); ?>