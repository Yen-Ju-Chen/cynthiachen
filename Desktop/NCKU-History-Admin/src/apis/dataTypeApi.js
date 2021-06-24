import axios from './base'

// 查詢所有資料
export const SearchDataType = data =>
  axios.post('/api/DataType/Query', data);
// 取得編輯資訊
export const GetDataTypeInfo = id =>
  axios.get(`/api/DataType/QueryDetail?id=${id}`);
// 新增/編輯
export const EditDataType = data =>
  axios.post('/api/DataType/UpdateDataType', data);

// 變更狀態
export const OffDataType = id =>
  axios.post(`/api/DataType/OffDataType?id=${id}`);
// 刪除
export const DeleteDataType = id =>
  axios.delete(`/api/DataType/DeleteDataType?id=${id}`);