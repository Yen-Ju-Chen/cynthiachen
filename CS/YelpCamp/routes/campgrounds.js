const express = require('express');
const router = express.Router();
const campgrounds = require('../controllers/campgrounds');
const catchAsync = require('../utils/catchAsync');
const ExpressError = require('../utils/expresserror');
const Campground = require('../models/campground');
const {isLoggedIn, isAuthor, validateCampground} = require('../middleware');
const multer  = require('multer');
const {storage} = require('../cloudinary') 
const upload = multer({ storage }); 


router.route('/')
//2.建首頁: find: 找尋資料庫資料; { campgrounds }: 把首頁資料傳去後端 整個資料所以複數
    .get(catchAsync(campgrounds.index))
//4.new page資料回傳: 建好new後要post資料至body，回傳後save，且別忘往回增express parse the body 的 func最後redirect到campground的show page(id)
////If: if not include this, we throw the error; throw the message to 'use' secction
//upload要在validate前面
    .post(isLoggedIn, upload.array('image'), validateCampground, catchAsync(campgrounds.createCampground))

//4.建new page: 要在id前面，不然會視為要建新的ID 
//**解好久的bug: res.render前面不用/!!
router.get('/new', isLoggedIn, campgrounds.renderNewForm);

router.route('/:id')
//3.show page(ID): findById(req.params.id): 找ID; campground：因為seeds/index.js設為單數(new item)
    .get(isLoggedIn, catchAsync(campgrounds.showCampground))
//5.edit page資料回傳： 用put method到show page(ID)，再分解動作，a.輸入id b.尋找id，這裏req.body.campground是從edit頁面中campground[title]等地方來的，再返回ID頁
    .put(isLoggedIn, isAuthor, upload.array('image'), validateCampground, catchAsync(campgrounds.updateCamground))
//6.delete item: 首先，要找到id才能刪除（方法如edit），再來用jquery找到id並刪除，最後返回首頁 
//不用設分頁，只需從show頁加連結上去即可
    .delete(isLoggedIn, isAuthor, catchAsync(campgrounds.deleteCampground))


//5.edit page: 從show page修改，所以路徑是長這樣，建好後從上面copy && paste find ID method後，再把資料傳回頁面
router.get('/:id/edit', isLoggedIn, isAuthor, catchAsync(campgrounds.renderEditForm));



module.exports = router;

//把一些東西從app.js搬過來，跟加回去make sure to export