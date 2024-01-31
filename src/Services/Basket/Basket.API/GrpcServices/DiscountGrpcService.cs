using Discount.Grpc.Protos;

namespace Basket.API.GrpcServices
{
    public class DiscountGrpcService
    {
        private readonly DiscountProtoService.DiscountProtoServiceClient _grpcClient;

        public DiscountGrpcService(DiscountProtoService.DiscountProtoServiceClient _grpcClient)
        {
            this._grpcClient = _grpcClient ?? throw new ArgumentNullException(nameof(_grpcClient));
        }

        public async Task<CouponModel> GetDiscount(string ProductName)
        {
            var discountRequest = new GetDiscountRequest { ProductName = ProductName };
            return await this._grpcClient.GetDiscountAsync(discountRequest);
        }
    }
}
