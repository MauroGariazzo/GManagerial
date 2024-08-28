

namespace GManagerial.Documents.OrderDocument.models
{
    internal class OrderDetails:IOrderDetails
    {
        private int _id;
        private int _fkOrder;
        private int _fkProduct;

        public OrderDetails(int fkOrder, int fk_product){
            _fkOrder = fkOrder;
            _fkProduct = fk_product;
        }   

        public int Id { get { return _id;} set { _id = value; } }
        public int FkOrder { get { return _fkOrder; } set { _fkOrder = value; } }
        public int FkProduct { get { return _fkProduct; } set { _fkProduct = value; } }

    }


}
