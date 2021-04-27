const express = require('express');
//review比較特別的是要mergeParams來叫出id
const router = express.Router({mergeParams: true});
const { validateReview, isLoggedIn, isReviewAuthor } = require('../middleware');
const Campground = require('../models/campground');
const Review = require('../models/review');
const reviews = require('../controllers/reviews')
const catchAsync = require('../utils/catchAsync');
const ExpressError = require('../utils/expresserror');


//campground.reviews在campground model中
//順序：先建schema 再route, showpage, error joi 再把畫面印出來
router.post('/', isLoggedIn, validateReview, catchAsync(reviews.createReview))

//pull that id and delete
router.delete('/:reviewId', isLoggedIn, isReviewAuthor, catchAsync(reviews.deleteReview))

module.exports = router;

