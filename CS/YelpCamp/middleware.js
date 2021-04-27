const { campgrondSchema, reviewSchema } = require('./schemas.js');
const ExpressError = require('./utils/expresserror');
const Campground = require('./models/campground');
const Review = require('./models/review');

module.exports.isLoggedIn = (req, res, next) => {
    if(!req.isAuthenticated()){
        req.session.returnTo = req.originalUrl
        req.flash('error', 'You must be signed in!');
        return res.redirect('/login');
    }
    next();
}

//創一個validateCampground 的 middleware，檢驗是否符合shema內容 並在需檢驗的(ex:new夾層)增加 middleware func (validateCampground)
//because detail is an array, we need to map it; we may have more than 1 string, so we use join to include all of them
module.exports.validateCampground = (req, res, next) => {
    
    const {error} = campgrondSchema.validate(req.body);
    if(error){
        const msg = error.details.map(el => el.message).join(',')
        throw new ExpressError(msg, 400)
    } else {
        next();
    }
}

module.exports.isAuthor = async(req, res, next) => {
    const { id } = req.params;
    const campground = await Campground.findById(id);
    if (!campground.author.equals(req.user._id)) {
        req.flash('error', 'You do not have permission to do that!');
        return res.redirect(`/campgrounds/${id}`);
    }
    next();
}

module.exports.isReviewAuthor = async(req, res, next) => {
    const { id, reviewId } = req.params;
    const review = await Review.findById(reviewId);
    if (!review.author.equals(req.user._id)) {
        req.flash('error', 'Yoe do not have permission to do that!');
        return res.redirect(`/campgrounds/${id}`)
    } 
    next();
}

module.exports.validateReview = (req, res, next) => {
    const { error } = reviewSchema.validate(req.body);
    if(error){
        const msg = error.details.map(el => el.message).join(',')
        throw new ExpressError(msg, 400)
    } else {
        next();
    }
}