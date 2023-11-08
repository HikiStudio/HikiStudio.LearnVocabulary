using HikiStudio.LearnVocabulary.Application.Interfaces;
using HikiStudio.LearnVocabulary.Data.EF;
using HikiStudio.LearnVocabulary.ViewModels.Common.API;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyWords;
using HikiStudio.LearnVocabulary.ViewModels.VocabularyWords.DataRequest;
using NetTopologySuite.Index.HPRtree;
using System.Linq;

namespace HikiStudio.LearnVocabulary.Application.Services
{
    public class TempVocabularyWordService : ITempVocabularyWordService
    {
        private readonly LanguageLearningDbContext _context;

        private readonly IVocabularyWordService _vocabularyWordService;

        public TempVocabularyWordService(LanguageLearningDbContext context, IVocabularyWordService vocabularyWordService)
        {
            _context = context;
            _vocabularyWordService = vocabularyWordService;
        }

        public async Task<APIResponse<bool>> SaveDataTempToDB()
        {
            var data = MapDataToTempVocabularyWords();

            HashSet<long> vocabularyIds = new HashSet<long>();
            foreach(var item in data)
            {
                //if (!vocabularyIds.Contains(item.VocabularyId))
                //{
                //    vocabularyIds.Add(item.VocabularyId);
                //}

                var createVocabularyWordRequest = new CreateVocabularyWordRequest()
                {
                    VocabularyTypeID = 1,
                    Word = item.Word,
                    Pronunciation = item.Pronunciation,
                    Definition = item.Meaning,
                    ExampleSentence = item.Example,
                    ExampleSentenceMeaning = item.ExampleMeaning
                };

                var result = await _vocabularyWordService.CreateVocabularyWordAsync(createVocabularyWordRequest);

                if (result.IsSuccessed)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Save Success With VocabularyID: " + item.VocabularyId + "...");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Save ERROR With VocabularyID: " + item.VocabularyId + " EX: " + result.Message);
                    Console.ResetColor();
                }

            }

            //for(long i = 1; i < 901; i++)
            //{
            //    if(i>401 && i < 500)
            //    {

            //    }
            //    else
            //    {
            //        if (!vocabularyIds.Contains(i))
            //        {
            //            result += i.ToString() + "|";
            //        }
            //    }
            //}

            return new APISuccessResponse<bool>() { Message = data.Count.ToString() };
        }

        private List<TempVocabularyWord> MapDataToTempVocabularyWords()
        {
            List<TempVocabularyWord> vocabularyWords = new List<TempVocabularyWord>();

            //#region 1-100
            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 1,
            //    Word = "Anyway",
            //    Pronunciation = "ˈɛniˌweɪ",
            //    Meaning = "Dù sao",
            //    Example = "Let's try anyway",
            //    ExampleMeaning = "Cứ thử đại đi!"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 2,
            //    Word = "Following",
            //    Pronunciation = "ˈfɑloʊɪŋ",
            //    Meaning = "Tiếp theo, sau khi",
            //    Example = "Following the speech, we had dinner",
            //    ExampleMeaning = "Sau bài phát biểu, chúng tôi đã ăn tối"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 3,
            //    Word = "Refer",
            //    Pronunciation = "rɪˈfɜr",
            //    Meaning = "Tham khảo",
            //    Example = "Please refer to the map",
            //    ExampleMeaning = "Vui lòng tham khảo bản đồ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 4,
            //    Word = "Available",
            //    Pronunciation = "əˈveɪləbəl",
            //    Meaning = "Có sẵn",
            //    Example = "Tickets are available online",
            //    ExampleMeaning = "Vé có sẵn trực tuyến"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 5,
            //    Word = "Department",
            //    Pronunciation = "dɪˈpɑrtmənt",
            //    Meaning = "Sở, phòng ban",
            //    Example = "The sales department",
            //    ExampleMeaning = "Bộ phận bán hàng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 6,
            //    Word = "Conference",
            //    Pronunciation = "ˈkɑnfrəns",
            //    Meaning = "Hội nghị",
            //    Example = "A large conference room",
            //    ExampleMeaning = "Một phòng hội nghị lớn"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 7,
            //    Word = "According to",
            //    Pronunciation = "əˈkɔrdɪŋ tu",
            //    Meaning = "Theo như",
            //    Example = "According to the email",
            //    ExampleMeaning = "Theo như email"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 8,
            //    Word = "Likely",
            //    Pronunciation = "ˈlaɪkli",
            //    Meaning = "Có khả năng",
            //    Example = "Who most likely is the woman?",
            //    ExampleMeaning = "Người phụ nữ có khả năng là ai?"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 9,
            //    Word = "Offer",
            //    Pronunciation = "ˈɔfər",
            //    Meaning = "Mời chào, giúp đỡ",
            //    Example = "What does the man offer to do?",
            //    ExampleMeaning = "Người đàn ông đề nghị làm gì?"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 10,
            //    Word = "Equipment",
            //    Pronunciation = "ɪˈkwɪpmənt",
            //    Meaning = "Trang thiết bị",
            //    Example = "New office equipment",
            //    ExampleMeaning = "Thiết bị văn phòng mới"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 11,
            //    Word = "Provide",
            //    Pronunciation = "prəˈvaɪd",
            //    Meaning = "Cung cấp",
            //    Example = "Please provide me with your email address",
            //    ExampleMeaning = "Vui lòng cung cấp cho tôi địa chỉ email của bạn"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 12,
            //    Word = "Local",
            //    Pronunciation = "ˈloʊkəl",
            //    Meaning = "Địa phương",
            //    Example = "Local businesses",
            //    ExampleMeaning = "Doanh nghiệp địa phương"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 13,
            //    Word = "Purchase",
            //    Pronunciation = "ˈpɜrʧəs",
            //    Meaning = "Mua",
            //    Example = "Purchase tickets",
            //    ExampleMeaning = "Mua vé"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 14,
            //    Word = "Opening",
            //    Pronunciation = "ˈoʊpənɪŋ",
            //    Meaning = "Khai mạc, trống",
            //    Example = "A job opening",
            //    ExampleMeaning = "Một vị trí đang trống"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 15,
            //    Word = "Construction",
            //    Pronunciation = "kənˈstrʌkʃən",
            //    Meaning = "Xây dựng",
            //    Example = "Construction project",
            //    ExampleMeaning = "Dự án xây dựng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 16,
            //    Word = "Tour",
            //    Pronunciation = "tʊr",
            //    Meaning = "Du lịch, đi tham quan",
            //    Example = "While touring the factory",
            //    ExampleMeaning = "Trong khi tham quan nhà máy"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 17,
            //    Word = "Research",
            //    Pronunciation = "ˈrisərʧ",
            //    Meaning = "Nghiên cứu",
            //    Example = "Market research",
            //    ExampleMeaning = "Nghiên cứu thị trường"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 18,
            //    Word = "Attend",
            //    Pronunciation = "əˈtɛnd",
            //    Meaning = "Tham gia",
            //    Example = "Attend a meeting",
            //    ExampleMeaning = "Dự một hội nghị"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 19,
            //    Word = "Delivery",
            //    Pronunciation = "dɪˈlɪvəri",
            //    Meaning = "Chuyển, giao hàng",
            //    Example = "Change delivery date",
            //    ExampleMeaning = "Thay đổi ngày giao hàng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 20,
            //    Word = "Recently",
            //    Pronunciation = "ˈrisəntli",
            //    Meaning = "Gần đây",
            //    Example = "I recently bought a printer",
            //    ExampleMeaning = "Gần đây, tôi đã mua một máy in"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 21,
            //    Word = "Indicates",
            //    Pronunciation = "ˈɪndɪˌkeɪts",
            //    Meaning = "Chỉ ra",
            //    Example = "What is indicated about Mr. Kato?",
            //    ExampleMeaning = "Thông tin nào đúng về ngài Kato?"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 22,
            //    Word = "Employee",
            //    Pronunciation = "ɪmˈplɔɪi",
            //    Meaning = "Nhân viên",
            //    Example = "An employee of a hotel",
            //    ExampleMeaning = "Một nhân viên của một khách sạn"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 23,
            //    Word = "Additional",
            //    Pronunciation = "əˈdɪʃənəl",
            //    Meaning = "Bổ sung, thêm vào",
            //    Example = "Request additional staff",
            //    ExampleMeaning = "Yêu cầu thêm nhân viên"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 24,
            //    Word = "Survey",
            //    Pronunciation = "ˈsɜrˌveɪ",
            //    Meaning = "Khảo sát",
            //    Example = "A customer survey",
            //    ExampleMeaning = "Một cuộc khảo sát khách hàng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 25,
            //    Word = "Review",
            //    Pronunciation = "ˌriˈvju",
            //    Meaning = "Ôn tập",
            //    Example = "Review a report",
            //    ExampleMeaning = "Xem lại một báo cáo"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 26,
            //    Word = "Production",
            //    Pronunciation = "prəˈdʌkʃən",
            //    Meaning = "Sản xuất",
            //    Example = "The production area",
            //    ExampleMeaning = "Khu vực sản xuất"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 27,
            //    Word = "Located",
            //    Pronunciation = "ˈloʊˌkeɪtəd",
            //    Meaning = "Nằm, đặt tại",
            //    Example = "Conveniently located near a subway station",
            //    ExampleMeaning = "Vị trí thuận tiện gần ga tàu điện ngầm"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 28,
            //    Word = "Detail",
            //    Pronunciation = "ˈditeɪl",
            //    Meaning = "Chi tiết",
            //    Example = "Details of a plan",
            //    ExampleMeaning = "Thông tin chi tiết về kế hoạch"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 29,
            //    Word = "Announce",
            //    Pronunciation = "əˈnaʊns",
            //    Meaning = "Thông báo",
            //    Example = "Announce the winners",
            //    ExampleMeaning = "Công bố người chiến thắng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 30,
            //    Word = "Repair",
            //    Pronunciation = "rɪˈpɛr",
            //    Meaning = "Sửa",
            //    Example = "A computer repair shop",
            //    ExampleMeaning = "Cửa hàng sửa chữa máy tính"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 31,
            //    Word = "Increase",
            //    Pronunciation = "ˈɪnˌkris",
            //    Meaning = "Tăng",
            //    Example = "An increase in sales",
            //    ExampleMeaning = "Sự tăng trưởng về doanh số"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 32,
            //    Word = "Include",
            //    Pronunciation = "ɪnˈklud",
            //    Meaning = "Bao gồm",
            //    Example = "What is not included in the form?",
            //    ExampleMeaning = "Cái gì không được đề cập trong tờ biểu mẫu?"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 33,
            //    Word = "Currently",
            //    Pronunciation = "ˈkɜrəntli",
            //    Meaning = "Hiện tại",
            //    Example = "The item is currently out of stock",
            //    ExampleMeaning = "Mặt hàng này hiện đang hết hàng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 34,
            //    Word = "Advertising",
            //    Pronunciation = "ˈædvərˌtaɪzɪŋ",
            //    Meaning = "Quảng cáo",
            //    Example = "An advertising campaign",
            //    ExampleMeaning = "Một chiến dịch quảng cáo"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 35,
            //    Word = "Charge",
            //    Pronunciation = "ʧɑrʤ",
            //    Meaning = "Sạc điện",
            //    Example = "We charge $50 for the service",
            //    ExampleMeaning = "Chúng tôi tính phí $50 cho dịch vụ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 36,
            //    Word = "Expect",
            //    Pronunciation = "ɪkˈspɛkt",
            //    Meaning = "Chờ đợi",
            //    Example = "Mr. Kato is expected to arrive tomorrow",
            //    ExampleMeaning = "Ngài Kato dự kiến sẽ đến vào ngày mai"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 37,
            //    Word = "Firm",
            //    Pronunciation = "fɜrm",
            //    Meaning = "Chắc chắn",
            //    Example = "A family-owned firm",
            //    ExampleMeaning = "Một công ty gia đình"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 38,
            //    Word = "Client",
            //    Pronunciation = "ˈklaɪənt",
            //    Meaning = "Khách hàng",
            //    Example = "Visit a client",
            //    ExampleMeaning = "Thăm khách hàng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 39,
            //    Word = "Financial",
            //    Pronunciation = "fəˈnænʃəl / ˌfaɪˈnænʃəl",
            //    Meaning = "Tài chính",
            //    Example = "Financial support from the government",
            //    ExampleMeaning = "Hỗ trợ tài chính từ chính phủ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 40,
            //    Word = "Annual",
            //    Pronunciation = "ˈænjuəl",
            //    Meaning = "Hàng năm",
            //    Example = "An annual report",
            //    ExampleMeaning = "Một báo cáo thường niên"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 41,
            //    Word = "Payment",
            //    Pronunciation = "ˈpeɪmənt",
            //    Meaning = "Thanh toán",
            //    Example = "Make an online payment",
            //    ExampleMeaning = "Thanh toán trực tuyến"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 42,
            //    Word = "Budget",
            //    Pronunciation = "ˈbʌʤɪt",
            //    Meaning = "Ngân sách",
            //    Example = "This year's budget",
            //    ExampleMeaning = "Ngân sách năm nay"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 43,
            //    Word = "Application",
            //    Pronunciation = "ˌæpləˈkeɪʃən",
            //    Meaning = "Ứng dụng",
            //    Example = "Fill out an application",
            //    ExampleMeaning = "Điền vào đơn xin việc"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 44,
            //    Word = "Contract",
            //    Pronunciation = "ˈkɑnˌtrækt",
            //    Meaning = "Hợp đồng",
            //    Example = "Before signing a contract",
            //    ExampleMeaning = "Trước khi ký hợp đồng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 45,
            //    Word = "Management",
            //    Pronunciation = "ˈmænəʤmənt",
            //    Meaning = "Sự quản lý, ban giám đốc",
            //    Example = "A management seminar",
            //    ExampleMeaning = "Một hội thảo quản lý"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 46,
            //    Word = "Performance",
            //    Pronunciation = "pərˈfɔrməns",
            //    Meaning = "Hiệu suất",
            //    Example = "An employee’s performance",
            //    ExampleMeaning = "Năng lực thành tích của một nhân viên"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 47,
            //    Word = "Pleased",
            //    Pronunciation = "plizd",
            //    Meaning = "Vừa lòng",
            //    Example = "We are pleased with the final result",
            //    ExampleMeaning = "Chúng tôi hài lòng với kết quả cuối cùng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 48,
            //    Word = "Confirm",
            //    Pronunciation = "kənˈfɜrm",
            //    Meaning = "Xác nhận",
            //    Example = "Confirm a payment",
            //    ExampleMeaning = "Xác nhận thanh toán"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 49,
            //    Word = "Award",
            //    Pronunciation = "əˈwɔrd",
            //    Meaning = "Giải thưởng",
            //    Example = "Award ceremony",
            //    ExampleMeaning = "Lễ trao giải"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 50,
            //    Word = "Clothing",
            //    Pronunciation = "ˈkloʊðɪŋ",
            //    Meaning = "Quần áo",
            //    Example = "A clothing store",
            //    ExampleMeaning = "Một cửa hàng quần áo"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 51,
            //    Word = "Display",
            //    Pronunciation = "dɪˈspleɪ",
            //    Meaning = "Trưng bày",
            //    Example = "Products on display",
            //    ExampleMeaning = "Sản phẩm được trưng bày"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 52,
            //    Word = "Candidate",
            //    Pronunciation = "ˈkændədeɪt",
            //    Meaning = "Thí sinh, ứng viên",
            //    Example = "Unsuccessful candidate",
            //    ExampleMeaning = "Ứng viên không thành công"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 53,
            //    Word = "State",
            //    Pronunciation = "steɪt",
            //    Meaning = "Đề cập, tuyên bố",
            //    Example = "What is stated about the hotel?",
            //    ExampleMeaning = "Điều gì được nêu về khách sạn?"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 54,
            //    Word = "Exhibit",
            //    Pronunciation = "ɪgˈzɪbɪt",
            //    Meaning = "Triển lãm, hiện vật",
            //    Example = "A museum exhibit",
            //    ExampleMeaning = "Một hiện vật"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 55,
            //    Word = "Session",
            //    Pronunciation = "ˈsɛʃən",
            //    Meaning = "Phiên, buổi",
            //    Example = "A Q&A session",
            //    ExampleMeaning = "Một buổi hỏi đáp"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 56,
            //    Word = "Note",
            //    Pronunciation = "noʊt",
            //    Meaning = "Ghi chú, chú thích",
            //    Example = "Please note that prices may change",
            //    ExampleMeaning = "Vui lòng chú ý rằng giá có thể thay đổi"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 57,
            //    Word = "Process",
            //    Pronunciation = "ˈprɔˌsɛs",
            //    Meaning = "Quá trình",
            //    Example = "Process an order",
            //    ExampleMeaning = "Xử lý một đơn đặt hàng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 58,
            //    Word = "Instruction",
            //    Pronunciation = "ɪnˈstrʌkʃən",
            //    Meaning = "Chỉ dẫn",
            //    Example = "Please read all the instructions",
            //    ExampleMeaning = "Xin vui lòng đọc tất cả các hướng dẫn"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 59,
            //    Word = "Membership",
            //    Pronunciation = "ˈmɛmbərˌʃɪp",
            //    Meaning = "Tư cách thành viên",
            //    Example = "Sign up for membership",
            //    ExampleMeaning = "Đăng ký thành viên"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 60,
            //    Word = "Agency",
            //    Pronunciation = "ˈeɪʤənsi",
            //    Meaning = "Đại lý",
            //    Example = "A travel agency",
            //    ExampleMeaning = "Một đại lý du lịch"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 61,
            //    Word = "Based",
            //    Pronunciation = "beɪst",
            //    Meaning = "Dựa trên",
            //    Example = "A Seattle-based company",
            //    ExampleMeaning = "Một công ty có trụ sở tại Seattle"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 62,
            //    Word = "Facility",
            //    Pronunciation = "fəˈsɪlɪti",
            //    Meaning = "Cơ sở",
            //    Example = "A research facility",
            //    ExampleMeaning = "Một cơ sở nghiên cứu"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 63,
            //    Word = "Advance",
            //    Pronunciation = "ədˈvæns",
            //    Meaning = "Nâng cao",
            //    Example = "Advance notice",
            //    ExampleMeaning = "Thông báo trước"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 64,
            //    Word = "Committee",
            //    Pronunciation = "kəˈmɪti",
            //    Meaning = "Ủy ban",
            //    Example = "Join a committee",
            //    ExampleMeaning = "Tham gia một ủy ban"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 65,
            //    Word = "Successful",
            //    Pronunciation = "səkˈsɛsfəl",
            //    Meaning = "Thành công",
            //    Example = "The event was successful",
            //    ExampleMeaning = "Sự kiện đã thành công"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 66,
            //    Word = "Excellent",
            //    Pronunciation = "ˈɛksələnt",
            //    Meaning = "Xuất sắc",
            //    Example = "Excellent service",
            //    ExampleMeaning = "Dịch vụ xuất sắc"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 67,
            //    Word = "Industry",
            //    Pronunciation = "ˈɪndəstri",
            //    Meaning = "Công nghiệp, ngành",
            //    Example = "The fashion industry",
            //    ExampleMeaning = "Ngành thời trang"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 68,
            //    Word = "Fee",
            //    Pronunciation = "fi",
            //    Meaning = "Lệ phí",
            //    Example = "Pay a late fee",
            //    ExampleMeaning = "Trả một khoản phí trễ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 69,
            //    Word = "Accept",
            //    Pronunciation = "əkˈsɛpt",
            //    Meaning = "Chấp nhận",
            //    Example = "Accept an offer",
            //    ExampleMeaning = "Chấp nhận một đề nghị"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 70,
            //    Word = "Upcoming",
            //    Pronunciation = "ˈʌpˌkʌmɪŋ",
            //    Meaning = "Sắp tới",
            //    Example = "Prepare for an upcoming event",
            //    ExampleMeaning = "Chuẩn bị cho một sự kiện sắp tới"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 71,
            //    Word = "Latest",
            //    Pronunciation = "ˈleɪtəst",
            //    Meaning = "Muộn nhất, mới nhất",
            //    Example = "Haruki Murakami’s latest novel",
            //    ExampleMeaning = "Cuốn tiểu thuyết mới nhất của Haruki Murakami"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 72,
            //    Word = "Submit",
            //    Pronunciation = "səbˈmɪt",
            //    Meaning = "Gửi đi",
            //    Example = "Submit a report",
            //    ExampleMeaning = "Nộp báo cáo"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 73,
            //    Word = "Transportation",
            //    Pronunciation = "ˌtrænspərˈteɪʃən",
            //    Meaning = "Vận chuyển",
            //    Example = "Use public transportation",
            //    ExampleMeaning = "Sử dụng giao thông công cộng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 74,
            //    Word = "Resumé",
            //    Pronunciation = "ˈrɛzəˌmeɪ",
            //    Meaning = "Đơn xin việc",
            //    Example = "Send a resume",
            //    ExampleMeaning = "Gửi đơn xin việc"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 75,
            //    Word = "Executive",
            //    Pronunciation = "ɪgˈzɛkjətɪv",
            //    Meaning = "Giám đốc cấp cao",
            //    Example = "A company executive (CEO, CFO, COO…)",
            //    ExampleMeaning = "Một giám đốc cấp cao (CEO, CFO, COO…)"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 76,
            //    Word = "Introduce",
            //    Pronunciation = "ˌɪntrəˈdus",
            //    Meaning = "Giới thiệu",
            //    Example = "Introduce a new line of products",
            //    ExampleMeaning = "Giới thiệu một dòng sản phẩm mới"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 77,
            //    Word = "Previous",
            //    Pronunciation = "ˈpriviəs",
            //    Meaning = "Trước",
            //    Example = "Have no previous experience",
            //    ExampleMeaning = "Chưa có kinh nghiệm trước đó"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 78,
            //    Word = "Proposal",
            //    Pronunciation = "prəˈpoʊzəl",
            //    Meaning = "Sự đề nghị",
            //    Example = "Review a proposal",
            //    ExampleMeaning = "Xem lại một đề xuất"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 79,
            //    Word = "Supply",
            //    Pronunciation = "ˈsʌpli",
            //    Meaning = "Cung cấp",
            //    Example = "Office supplies",
            //    ExampleMeaning = "Văn phòng phẩm"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 80,
            //    Word = "Enclosed",
            //    Pronunciation = "ɪnˈkloʊzd",
            //    Meaning = "Đính kèm, trong nhà",
            //    Example = "My resume is enclosed",
            //    ExampleMeaning = "Đơn xin việc của tôi được kính kèm."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 81,
            //    Word = "Policy",
            //    Pronunciation = "ˈpɑləsi",
            //    Meaning = "Chính sách",
            //    Example = "Returns policy",
            //    ExampleMeaning = "Chính sách hoàn trả"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 82,
            //    Word = "Register",
            //    Pronunciation = "ˈrɛʤɪstər",
            //    Meaning = "Ghi danh, đăng kí",
            //    Example = "Register for employee training",
            //    ExampleMeaning = "Đăng ký lớp đào tạo cho nhân viên"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 83,
            //    Word = "Arrange",
            //    Pronunciation = "əˈreɪnʤ",
            //    Meaning = "Sắp xếp",
            //    Example = "Arrange a meeting",
            //    ExampleMeaning = "Sắp xếp buổi gặp mặt"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 84,
            //    Word = "Bill",
            //    Pronunciation = "bɪl",
            //    Meaning = "Hóa đơn",
            //    Example = "Receive a bill",
            //    ExampleMeaning = "Nhận hóa đơn"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 85,
            //    Word = "Hire",
            //    Pronunciation = "ˈhaɪər",
            //    Meaning = "Thuê",
            //    Example = "Hire an assistant",
            //    ExampleMeaning = "Thuê một trợ lý"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 86,
            //    Word = "Approve",
            //    Pronunciation = "əˈpruv",
            //    Meaning = "Phê duyệt",
            //    Example = "Approve the plan",
            //    ExampleMeaning = "Phê duyệt kế hoạch"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 87,
            //    Word = "Conduct",
            //    Pronunciation = "kənˈdʌkt",
            //    Meaning = "Tiến hành",
            //    Example = "Conduct the survey",
            //    ExampleMeaning = "Tiến hành khảo sát"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 88,
            //    Word = "Opportunity",
            //    Pronunciation = "ˌɑpərˈtunəti",
            //    Meaning = "Cơ hội",
            //    Example = "An opportunity to work with you",
            //    ExampleMeaning = "Một cơ hội để làm việc với bạn"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 89,
            //    Word = "Deadline",
            //    Pronunciation = "ˈdɛˌdlaɪn",
            //    Meaning = "Hạn chót",
            //    Example = "The deadline for the project",
            //    ExampleMeaning = "Thời hạn cho dự án"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 90,
            //    Word = "Corporate",
            //    Pronunciation = "ˈkɔrpərət",
            //    Meaning = "Công ty",
            //    Example = "A corporate trainer",
            //    ExampleMeaning = "Một chuyên viên đào tạo của công ty"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 91,
            //    Word = "Warranty",
            //    Pronunciation = "ˈwɔrənti",
            //    Meaning = "Sự bảo đảm, bảo hành",
            //    Example = "A 3-year warranty",
            //    ExampleMeaning = "Bảo hành 3 năm"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 92,
            //    Word = "Necessary",
            //    Pronunciation = "ˈnɛsəˌsɛri",
            //    Meaning = "Cần thiết",
            //    Example = "Necessary forms",
            //    ExampleMeaning = "Các đơn cần thiết"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 93,
            //    Word = "Reserve",
            //    Pronunciation = "rɪˈzɜrv",
            //    Meaning = "Dự trữ, đặt chỗ",
            //    Example = "Reserve a room at a hotel",
            //    ExampleMeaning = "Đặt phòng tại khách sạn"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 94,
            //    Word = "Resident",
            //    Pronunciation = "ˈrɛzɪdənt",
            //    Meaning = "Cư dân",
            //    Example = "Local residents",
            //    ExampleMeaning = "Cư dân địa phương"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 95,
            //    Word = "Create",
            //    Pronunciation = "kriˈeɪt",
            //    Meaning = "Tạo nên",
            //    Example = "Create a new logo",
            //    ExampleMeaning = "Tạo logo mới"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 96,
            //    Word = "Inform",
            //    Pronunciation = "ɪnˈfɔrm",
            //    Meaning = "Thông báo",
            //    Example = "We are happy to inform you that",
            //    ExampleMeaning = "Chúng tôi vui mừng thông báo cho bạn rằng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 97,
            //    Word = "Allow",
            //    Pronunciation = "əˈlaʊ",
            //    Meaning = "Cho phép",
            //    Example = "Allow customers to pay online",
            //    ExampleMeaning = "Cho phép khách hàng thanh toán trực tuyến"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 98,
            //    Word = "Mention",
            //    Pronunciation = "ˈmɛnʃən",
            //    Meaning = "Đề cập",
            //    Example = "What problem does the man mention?",
            //    ExampleMeaning = "Người đàn ông đề cập đến vấn đề gì?"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 99,
            //    Word = "Appreciate",
            //    Pronunciation = "əˈpriʃiˌeɪt",
            //    Meaning = "Cảm kích",
            //    Example = "I really appreciate your help",
            //    ExampleMeaning = "Tôi thực sự đánh giá cao sự giúp đỡ của bạn"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 100,
            //    Word = "Replacement",
            //    Pronunciation = "rɪˈpleɪsmənt",
            //    Meaning = "Sản phẩm thay thế",
            //    Example = "Replacement parts",
            //    ExampleMeaning = "Phần, phụ tùng thay thế"
            //});
            //#endregion

            #region 101-200
            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 101,
            //    Word = "Update",
            //    Pronunciation = "ˈʌpˌdeɪt",
            //    Meaning = "Cập nhật",
            //    Example = "Traffic updates",
            //    ExampleMeaning = "Cập nhật giao thông"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 102,
            //    Word = "Branch",
            //    Pronunciation = "brænʧ",
            //    Meaning = "Chi nhánh",
            //    Example = "Opening new branch",
            //    ExampleMeaning = "Khai trương chi nhánh mới"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 103,
            //    Word = "Paid",
            //    Pronunciation = "peɪd",
            //    Meaning = "Đã thanh toán",
            //    Example = "Paid leaves",
            //    ExampleMeaning = "Nghỉ có lương"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 104,
            //    Word = "Unfortunately",
            //    Pronunciation = "ənˈfɔrʧunətli",
            //    Meaning = "Không may",
            //    Example = "Unfortunately, there are some problems",
            //    ExampleMeaning = "Thật không may, có một số vấn đề"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 105,
            //    Word = "Original",
            //    Pronunciation = "əˈrɪʤənəl",
            //    Meaning = "Nguyên thủy",
            //    Example = "In original condition",
            //    ExampleMeaning = "Còn nguyên vẹn"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 106,
            //    Word = "Rent",
            //    Pronunciation = "rɛnt",
            //    Meaning = "Thuê",
            //    Example = "A rent increase",
            //    ExampleMeaning = "Tăng tiền thuê"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 107,
            //    Word = "Memo",
            //    Pronunciation = "ˈmɛˌmoʊ",
            //    Meaning = "Bản tin, bảng ghi nhớ",
            //    Example = "Writing memo",
            //    ExampleMeaning = "Viết ghi nhớ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 108,
            //    Word = "Luggage",
            //    Pronunciation = "ˈlʌgɪʤ",
            //    Meaning = "Hành lý",
            //    Example = "Shop for luggage",
            //    ExampleMeaning = "Cửa hàng hành lý"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 109,
            //    Word = "Editor",
            //    Pronunciation = "ˈɛdɪtər",
            //    Meaning = "Biên tập viên",
            //    Example = "Newspaper editor",
            //    ExampleMeaning = "Biên tập viên báo"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 110,
            //    Word = "Exhibition",
            //    Pronunciation = "ˌɛksəˈbɪʃən",
            //    Meaning = "Triển lãm",
            //    Example = "An art exhibition",
            //    ExampleMeaning = "Triển lãm nghệ thuật"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 111,
            //    Word = "Leading",
            //    Pronunciation = "ˈlidɪŋ",
            //    Meaning = "Dẫn đầu",
            //    Example = "A leading company",
            //    ExampleMeaning = "Một công ty hàng đầu"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 112,
            //    Word = "Organization",
            //    Pronunciation = "ˌɔrgənəˈzeɪʃən",
            //    Meaning = "Cơ quan",
            //    Example = "Lead an organization",
            //    ExampleMeaning = "Lãnh đạo 1 tổ chức"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 113,
            //    Word = "Release",
            //    Pronunciation = "riˈlis",
            //    Meaning = "Giải phóng",
            //    Example = "Release a new album",
            //    ExampleMeaning = "Phát hành album mới"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 114,
            //    Word = "Limited",
            //    Pronunciation = "ˈlɪmɪtɪd",
            //    Meaning = "Hạn chế",
            //    Example = "For a limited time",
            //    ExampleMeaning = "Trong một thời gian hạn chế"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 115,
            //    Word = "Procedure",
            //    Pronunciation = "proʊˈsiʤər",
            //    Meaning = "Thủ tục",
            //    Example = "A normal procedure",
            //    ExampleMeaning = "Một thủ tục bình thường"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 116,
            //    Word = "Experienced",
            //    Pronunciation = "ɪkˈspɪriənst",
            //    Meaning = "Có kinh nghiệm",
            //    Example = "An experienced engineer",
            //    ExampleMeaning = "Một kỹ sư giàu kinh nghiệm"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 117,
            //    Word = "Personal",
            //    Pronunciation = "ˈpɜrsɪnɪl",
            //    Meaning = "Cá nhân",
            //    Example = "All company personnel",
            //    ExampleMeaning = "Tất cả nhân viên công ty"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 118,
            //    Word = "Author",
            //    Pronunciation = "ˈɔθər",
            //    Meaning = "Tác giả",
            //    Example = "The author of a popular book",
            //    ExampleMeaning = "Tác giả của một cuốn sách nổi tiếng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 119,
            //    Word = "Benefit",
            //    Pronunciation = "ˈbɛnəfɪt",
            //    Meaning = "Lợi ích",
            //    Example = "Employee benefits",
            //    ExampleMeaning = "Phúc lợi của nhân viên"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 120,
            //    Word = "Focus",
            //    Pronunciation = "ˈfoʊkəs",
            //    Meaning = "Tiêu điểm, tập trung",
            //    Example = "Focus on one point",
            //    ExampleMeaning = "Tập trung vào một điểm"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 121,
            //    Word = "Participate",
            //    Pronunciation = "pɑrˈtɪsəˌpeɪt",
            //    Meaning = "Tham dự",
            //    Example = "Participate in the workshop",
            //    ExampleMeaning = "Tham gia hội thảo"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 122,
            //    Word = "Cause",
            //    Pronunciation = "kɔz",
            //    Meaning = "Nguyên nhân, gây ra",
            //    Example = "The cause of the problem",
            //    ExampleMeaning = "Nguyên nhân của vấn đề"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 123,
            //    Word = "Degree",
            //    Pronunciation = "dɪˈgri",
            //    Meaning = "Trình độ, bằng cấp",
            //    Example = "A degree in Journalism",
            //    ExampleMeaning = "Bằng cấp về báo chí"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 124,
            //    Word = "Directly",
            //    Pronunciation = "daɪˈrɛkli",
            //    Meaning = "Trực tiếp",
            //    Example = "Purchase directly from a website",
            //    ExampleMeaning = "Mua trực tiếp từ một trang web"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 125,
            //    Word = "Host",
            //    Pronunciation = "hoʊst",
            //    Meaning = "Chủ nhà, thiết đãi",
            //    Example = "The host of a television show",
            //    ExampleMeaning = "Người dẫn chương trình truyền hình"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 126,
            //    Word = "Expert",
            //    Pronunciation = "ˈɛkspərt",
            //    Meaning = "Chuyên gia",
            //    Example = "An expert in the field",
            //    ExampleMeaning = "Một chuyên gia trong lĩnh vực này"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 127,
            //    Word = "Impressed",
            //    Pronunciation = "ɪmˈprɛst",
            //    Meaning = "Ấn tượng",
            //    Example = "We were impressed by your knowledge",
            //    ExampleMeaning = "Chúng tôi đã rất ấn tượng bởi kiến thức của bạn"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 128,
            //    Word = "Mainly",
            //    Pronunciation = "ˈmeɪnli",
            //    Meaning = "Chủ yếu",
            //    Example = "Work mainly in the steel industry",
            //    ExampleMeaning = "Làm việc chủ yếu trong ngành thép"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 129,
            //    Word = "Suggestion",
            //    Pronunciation = "səgˈʤɛsʧən",
            //    Meaning = "Gợi ý, đề xuất",
            //    Example = "Make suggestions",
            //    ExampleMeaning = "Góp ý kiến"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 130,
            //    Word = "Supplier",
            //    Pronunciation = "səˈplaɪər",
            //    Meaning = "Nhà cung cấp",
            //    Example = "Relationships with suppliers",
            //    ExampleMeaning = "Mối quan hệ với các nhà cung cấp"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 131,
            //    Word = "Document",
            //    Pronunciation = "ˈdɑkjumɛnt",
            //    Meaning = "Tài liệu, ghi chú",
            //    Example = "An important document",
            //    ExampleMeaning = "Một tài liệu quan trọng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 132,
            //    Word = "Remind",
            //    Pronunciation = "riˈmaɪnd",
            //    Meaning = "Nhắc nhở",
            //    Example = "Remind employees about the policy",
            //    ExampleMeaning = "Nhắc nhở nhân viên về chính sách"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 133,
            //    Word = "Require",
            //    Pronunciation = "ˌriˈkwaɪər",
            //    Meaning = "Yêu cầu",
            //    Example = "Workers are required to wear uniforms",
            //    ExampleMeaning = "Công nhân được yêu cầu mặc đồng phục"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 134,
            //    Word = "Representative",
            //    Pronunciation = "ˌrɛprɪˈzɛntətɪv",
            //    Meaning = "Người đại diện, Tiêu biểu",
            //    Example = "A sales representative",
            //    ExampleMeaning = "Một đại diện bán hàng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 135,
            //    Word = "Packaging",
            //    Pronunciation = "ˈpækɪʤɪŋ",
            //    Meaning = "Bao bì",
            //    Example = "The packaging area",
            //    ExampleMeaning = "Khu vực đóng gói"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 136,
            //    Word = "Description",
            //    Pronunciation = "dɪˈskrɪpʃən",
            //    Meaning = "Sự miêu tả",
            //    Example = "A job description",
            //    ExampleMeaning = "Mô tả công việc"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 137,
            //    Word = "Property",
            //    Pronunciation = "ˈprɑpərti",
            //    Meaning = "Bất động sản, tài sản",
            //    Example = "A property manager",
            //    ExampleMeaning = "Một người quản lý tài sản"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 138,
            //    Word = "Extension",
            //    Pronunciation = "ɪkˈstɛnʃən",
            //    Meaning = "Sự mở rộng, số nội bộ",
            //    Example = "Call me at extension 4649",
            //    ExampleMeaning = "Gọi cho tôi tại số máy lẻ 4649"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 139,
            //    Word = "Inquire",
            //    Pronunciation = "ɪnˈkwaɪr",
            //    Meaning = "Hỏi",
            //    Example = "Inquire about a job",
            //    ExampleMeaning = "Hỏi về một công việc"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 140,
            //    Word = "Merchandise",
            //    Pronunciation = "ˈmɜrʧənˌdaɪz",
            //    Meaning = "Hàng hóa",
            //    Example = "Display merchandise",
            //    ExampleMeaning = "Trưng bày hàng hóa"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 141,
            //    Word = "Highly",
            //    Pronunciation = "ˈhaɪli",
            //    Meaning = "Cao",
            //    Example = "Highly successful business",
            //    ExampleMeaning = "Doanh nghiệp cực kì thành công"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 142,
            //    Word = "Result",
            //    Pronunciation = "rɪˈzʌlt",
            //    Meaning = "Kết quả",
            //    Example = "The campaign resulted in success",
            //    ExampleMeaning = "Chiến dịch đã mang lại thành công."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 143,
            //    Word = "Assistance",
            //    Pronunciation = "əˈsɪstəns",
            //    Meaning = "Hỗ trợ",
            //    Example = "Thank you for your assistance",
            //    ExampleMeaning = "Cám ơn sự giúp đỡ của bạn"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 144,
            //    Word = "Encourage",
            //    Pronunciation = "ɪnˈkɜrəʤ",
            //    Meaning = "Khuyến khích",
            //    Example = "Employees are encouraged to attend the event",
            //    ExampleMeaning = "Nhân viên được khuyến khích tham dự sự kiện"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 145,
            //    Word = "Individual",
            //    Pronunciation = "ˌɪndəˈvɪʤəwəl",
            //    Meaning = "Cá nhân",
            //    Example = "Each individual in the company",
            //    ExampleMeaning = "Mỗi cá nhân trong công ty"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 146,
            //    Word = "Laboratory",
            //    Pronunciation = "ˈlæbrəˌtɔri",
            //    Meaning = "Phòng thí nghiệm",
            //    Example = "When entering the laboratory",
            //    ExampleMeaning = "Khi vào phòng thí nghiệm"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 147,
            //    Word = "Consider",
            //    Pronunciation = "kənˈsɪdər",
            //    Meaning = "Xem xét",
            //    Example = "Consider working in Japan",
            //    ExampleMeaning = "Cân nhắc làm việc tại Nhật Bản"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 148,
            //    Word = "Headquarters",
            //    Pronunciation = "ˈhɛdˌkwɔrtərz",
            //    Meaning = "Trụ sở chính",
            //    Example = "Move the headquarters to Boston",
            //    ExampleMeaning = "Chuyển trụ sở đến Boston"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 149,
            //    Word = "Ship",
            //    Pronunciation = "ʃɪp",
            //    Meaning = "Chuyển hàng, tàu",
            //    Example = "We are ready to ship your order",
            //    ExampleMeaning = "Chúng tôi đã sẵn sàng để gửi đơn hàng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 150,
            //    Word = "Commercial",
            //    Pronunciation = "kəˈmɜrʃəl",
            //    Meaning = "Thương mại",
            //    Example = "Commercial buildings",
            //    ExampleMeaning = "Tòa nhà thương mại"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 151,
            //    Word = "Device",
            //    Pronunciation = "dɪˈvaɪs",
            //    Meaning = "Thiết bị",
            //    Example = "A medical device",
            //    ExampleMeaning = "Một thiết bị y tế"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 152,
            //    Word = "Intended",
            //    Pronunciation = "ɪnˈtɛndɪd",
            //    Meaning = "Dành cho",
            //    Example = "For whom is the notice intended?",
            //    ExampleMeaning = "Thông báo dành cho ai?"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 153,
            //    Word = "Brochure",
            //    Pronunciation = "broʊˈʃʊr",
            //    Meaning = "Sách giới thiệu",
            //    Example = "A product brochure",
            //    ExampleMeaning = "Tài liệu giới thiệu sản phẩm"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 154,
            //    Word = "Mail",
            //    Pronunciation = "meɪl",
            //    Meaning = "Thư, gửi qua bưu điện",
            //    Example = "By express mail",
            //    ExampleMeaning = "Bằng thư chuyển phát nhanh"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 155,
            //    Word = "Prefer",
            //    Pronunciation = "prɪˈfɜr",
            //    Meaning = "Thích hơn",
            //    Example = "I prefer to work part-time",
            //    ExampleMeaning = "Tôi thích làm việc bán thời gian"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 156,
            //    Word = "Response",
            //    Pronunciation = "rɪˈspɑns",
            //    Meaning = "Phản hồi",
            //    Example = "I am writing in response to your letter",
            //    ExampleMeaning = "Tôi đang viết thư trả lời thư của bạn"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 157,
            //    Word = "Region",
            //    Pronunciation = "ˈriʤən",
            //    Meaning = "Khu vực",
            //    Example = "Companies in the region",
            //    ExampleMeaning = "Các công ty trong khu vực"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 158,
            //    Word = "Donation",
            //    Pronunciation = "doʊˈneɪʃən",
            //    Meaning = "Quyên góp",
            //    Example = "Donations to a museum",
            //    ExampleMeaning = "Đóng góp cho một bảo tàng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 159,
            //    Word = "Quarter",
            //    Pronunciation = "ˈkwɔrtər",
            //    Meaning = "Phần tư, Quý",
            //    Example = "The third quarter",
            //    ExampleMeaning = "Quý thứ ba"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 160,
            //    Word = "Agreement",
            //    Pronunciation = "əˈgrimənt",
            //    Meaning = "Hiệp định, hợp đồng",
            //    Example = "A rental agreement",
            //    ExampleMeaning = "Hợp đồng cho thuê"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 161,
            //    Word = "Journal",
            //    Pronunciation = "ˈʤɜrnəl",
            //    Meaning = "Tạp chí",
            //    Example = "A scientific journal",
            //    ExampleMeaning = "Một tạp chí khoa học"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 162,
            //    Word = "Distribute",
            //    Pronunciation = "dɪˈstrɪbjut",
            //    Meaning = "Phân phát",
            //    Example = "Distribute a document",
            //    ExampleMeaning = "Phân phát tài liệu"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 163,
            //    Word = "Potential",
            //    Pronunciation = "pəˈtɛnʃəl",
            //    Meaning = "Tiềm năng",
            //    Example = "Potential customers",
            //    ExampleMeaning = "Khách hàng tiềm năng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 164,
            //    Word = "Reschedule",
            //    Pronunciation = "riˈskɛʤul",
            //    Meaning = "Sắp xếp lại",
            //    Example = "Reschedule an appointment",
            //    ExampleMeaning = "Sắp xếp lại một cuộc hẹn"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 165,
            //    Word = "Renew",
            //    Pronunciation = "rɪˈnu",
            //    Meaning = "Thay mới, gia hạn",
            //    Example = "Renew a contract",
            //    ExampleMeaning = "Gia hạn hợp đồng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 166,
            //    Word = "Warehouse",
            //    Pronunciation = "ˈwɛrˌhaʊs",
            //    Meaning = "Nhà kho",
            //    Example = "Ship from a warehouse",
            //    ExampleMeaning = "Vận chuyển từ kho"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 167,
            //    Word = "Refund",
            //    Pronunciation = "ˈriˌfʌnd",
            //    Meaning = "Hoàn tiền",
            //    Example = "A full refund",
            //    ExampleMeaning = "Hoàn trả đầy đủ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 168,
            //    Word = "Advise",
            //    Pronunciation = "ədˈvaɪz",
            //    Meaning = "Khuyên nhủ",
            //    Example = "What are the listeners advised to do?",
            //    ExampleMeaning = "Những người nghe được khuyên nên làm gì?"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 169,
            //    Word = "Immediately",
            //    Pronunciation = "ɪˈmidiətli",
            //    Meaning = "Ngay",
            //    Example = "The tickets sold out immediately",
            //    ExampleMeaning = "Vé đã bán hết ngay lập tức."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 170,
            //    Word = "Council",
            //    Pronunciation = "ˈkaʊnsəl",
            //    Meaning = "Hội đồng",
            //    Example = "The city council",
            //    ExampleMeaning = "Hội đồng thành phố"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 171,
            //    Word = "Broadcast",
            //    Pronunciation = "ˈbrɔdˌkæst",
            //    Meaning = "Phát sóng",
            //    Example = "The program is usually broadcast on Saturday",
            //    ExampleMeaning = "Chương trình thường được phát vào thứ bảy"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 172,
            //    Word = "Responsible",
            //    Pronunciation = "riˈspɑnsəbəl",
            //    Meaning = "Chịu trách nhiệm",
            //    Example = "I am responsible for training employees",
            //    ExampleMeaning = "Tôi chịu trách nhiệm đào tạo nhân viên"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 173,
            //    Word = "Avoid",
            //    Pronunciation = "əˈvɔɪd",
            //    Meaning = "Tránh",
            //    Example = "Avoid wasting time",
            //    ExampleMeaning = "Tránh lãng phí thời gian"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 174,
            //    Word = "Effective",
            //    Pronunciation = "ɪˈfɛktɪv",
            //    Meaning = "Có hiệu lực",
            //    Example = "Effective advertising campaigns",
            //    ExampleMeaning = "Chiến dịch quảng cáo hiệu quả"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 175,
            //    Word = "Invitation",
            //    Pronunciation = "ˌɪnvɪˈteɪʃən",
            //    Meaning = "Lời mời",
            //    Example = "Receive an invitation",
            //    ExampleMeaning = "Nhận lời mời"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 176,
            //    Word = "Reduce",
            //    Pronunciation = "rɪˈdus",
            //    Meaning = "Giảm",
            //    Example = "Reduce prices",
            //    ExampleMeaning = "Giảm giá"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 177,
            //    Word = "Vehicle",
            //    Pronunciation = "ˈviɪkəl",
            //    Meaning = "Phương tiện giao thông",
            //    Example = "Park a vehicle",
            //    ExampleMeaning = "Đỗ xe"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 178,
            //    Word = "Efficient",
            //    Pronunciation = "ɪˈfɪʃənt",
            //    Meaning = "Hiệu quả",
            //    Example = "Efficient use of energy",
            //    ExampleMeaning = "Sử dụng năng lượng hiệu quả"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 179,
            //    Word = "Manufacturer",
            //    Pronunciation = "ˌmænjəˈfækʧərər",
            //    Meaning = "Nhà sản xuất",
            //    Example = "A car manufacturer",
            //    ExampleMeaning = "Một nhà sản xuất xe hơi"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 180,
            //    Word = "Comfortable",
            //    Pronunciation = "ˈkʌmfərtəbəl",
            //    Meaning = "Thoải mái",
            //    Example = "Comfortable rooms and friendly staff",
            //    ExampleMeaning = "Phòng thoải mái và nhân viên thân thiện"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 181,
            //    Word = "Correct",
            //    Pronunciation = "kəˈrɛkt",
            //    Meaning = "Chính xác, sửa",
            //    Example = "The correct address",
            //    ExampleMeaning = "Địa chỉ chính xác"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 182,
            //    Word = "Downtown",
            //    Pronunciation = "ˈdaʊnˈtaʊn",
            //    Meaning = "Khu trung tâm",
            //    Example = "Downtown restaurants",
            //    ExampleMeaning = "Nhà hàng trung tâm"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 183,
            //    Word = "Method",
            //    Pronunciation = "ˈmɛθəd",
            //    Meaning = "Phương pháp",
            //    Example = "The method of payment",
            //    ExampleMeaning = "Phương thức thanh toán"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 184,
            //    Word = "Entire",
            //    Pronunciation = "ɪnˈtaɪər",
            //    Meaning = "Toàn bộ",
            //    Example = "The entire staff",
            //    ExampleMeaning = "Toàn thể nhân viên"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 185,
            //    Word = "Range",
            //    Pronunciation = "reɪnʤ",
            //    Meaning = "Phạm vi",
            //    Example = "A wide range of services",
            //    ExampleMeaning = "Một loạt các dịch vụ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 186,
            //    Word = "Setting",
            //    Pronunciation = "ˈsɛtɪŋ",
            //    Meaning = "Cài đặt",
            //    Example = "A hotel in a beautiful setting",
            //    ExampleMeaning = "Một khách sạn trong một khung cảnh đẹp"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 187,
            //    Word = "Apologize",
            //    Pronunciation = "əˈpɑləˌʤaɪz",
            //    Meaning = "Xin lỗi",
            //    Example = "We apologize for the inconvenience",
            //    ExampleMeaning = "Chúng tôi xin lỗi vì sự bất tiện này"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 188,
            //    Word = "Frequent",
            //    Pronunciation = "ˈfrikwənt",
            //    Meaning = "Thường xuyên",
            //    Example = "Frequent use of the internet",
            //    ExampleMeaning = "Sử dụng internet thường xuyên"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 189,
            //    Word = "Promotion",
            //    Pronunciation = "prəˈmoʊʃən",
            //    Meaning = "Khuyến mãi, thăng chức",
            //    Example = "Tex’s promotion to sales manager",
            //    ExampleMeaning = "Sự thăng chức lên giám đốc bán hàng của Tex"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 190,
            //    Word = "Regarding",
            //    Pronunciation = "rɪˈgɑrdɪŋ",
            //    Meaning = "Về",
            //    Example = "Regarding your order",
            //    ExampleMeaning = "Về đơn hàng của bạn"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 191,
            //    Word = "Temporary",
            //    Pronunciation = "ˈtɛmpəˌrɛri",
            //    Meaning = "Tạm thời",
            //    Example = "Temporary workers",
            //    ExampleMeaning = "Lao động tạm thời"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 192,
            //    Word = "Traditional",
            //    Pronunciation = "trəˈdɪʃənəl",
            //    Meaning = "Truyền thống",
            //    Example = "Traditional Italian dishes",
            //    ExampleMeaning = "Món ăn truyền thống của Ý"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 193,
            //    Word = "Admission",
            //    Pronunciation = "ədˈmɪʃən",
            //    Meaning = "Nhận vào, nhập viện",
            //    Example = "Admission is free for all members",
            //    ExampleMeaning = "Vào cửa miễn phí cho tất cả các thành viên"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 194,
            //    Word = "Fit",
            //    Pronunciation = "fɪt",
            //    Meaning = "Phù hợp",
            //    Example = "The room can fit 50 people",
            //    ExampleMeaning = "Phòng có thể chứa 50 người"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 195,
            //    Word = "Reference",
            //    Pronunciation = "ˈrɛfərəns",
            //    Meaning = "Tài liệu hoặc người tham khảo",
            //    Example = "Contact a reference",
            //    ExampleMeaning = "Liên hệ người chứng thực"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 196,
            //    Word = "Status",
            //    Pronunciation = "ˈstætəs",
            //    Meaning = "Trạng thái",
            //    Example = "Shipment status",
            //    ExampleMeaning = "Tình trạng giao hàng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 197,
            //    Word = "Fuel",
            //    Pronunciation = "ˈfjuəl",
            //    Meaning = "Nhiên liệu",
            //    Example = "Fuel cost",
            //    ExampleMeaning = "Chi phí nhiên liệu"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 198,
            //    Word = "Nearly",
            //    Pronunciation = "ˈnɪrli",
            //    Meaning = "Gần",
            //    Example = "Nearly 2 years",
            //    ExampleMeaning = "Gần 2 năm"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 199,
            //    Word = "Cafeteria",
            //    Pronunciation = "ˌkæfəˈtɪriə",
            //    Meaning = "Quán cà phê",
            //    Example = "Meet in the cafeteria for lunch",
            //    ExampleMeaning = "Gặp nhau trong quán ăn trưa"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 200,
            //    Word = "Determine",
            //    Pronunciation = "dɪˈtɜrmən",
            //    Meaning = "Xác định, quyết tâm",
            //    Example = "Determine how to sell the product",
            //    ExampleMeaning = "Xác định cách bán sản phẩm"
            //});
            #endregion

            //#region 201-300
            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 201,
            //    Word = "Expense",
            //    Pronunciation = "ɪkˈspɛns",
            //    Meaning = "Chi phí",
            //    Example = "Travel expenses",
            //    ExampleMeaning = "Chi phí đi lại"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 202,
            //    Word = "Overseas",
            //    Pronunciation = "ˈoʊvərˈsiz",
            //    Meaning = "Hải ngoại",
            //    Example = "Overseas market",
            //    ExampleMeaning = "Thị trường nước ngoài"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 203,
            //    Word = "Satisfied",
            //    Pronunciation = "ˈsætɪˌsfaɪd",
            //    Meaning = "Hài lòng",
            //    Example = "I am fully satisfied with the service",
            //    ExampleMeaning = "Tôi hoàn toàn hài lòng với dịch vụ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 204,
            //    Word = "Appear",
            //    Pronunciation = "əˈpɪr",
            //    Meaning = "Xuất hiện",
            //    Example = "Where would the article most likely appear?",
            //    ExampleMeaning = "Bài viết có khả năng xuất hiện ở đâu?"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 205,
            //    Word = "Develop",
            //    Pronunciation = "dɪˈvɛləp",
            //    Meaning = "Phát triển, xây dựng",
            //    Example = "Develop a plan",
            //    ExampleMeaning = "Triển khai một kế hoạch"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 206,
            //    Word = "Improve",
            //    Pronunciation = "ɪmˈpruv",
            //    Meaning = "Cải tiến",
            //    Example = "Improve customer service",
            //    ExampleMeaning = "Cải thiện dịch vụ khách hàng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 207,
            //    Word = "Reasonable",
            //    Pronunciation = "ˈrizənəbəl",
            //    Meaning = "Hợp lý",
            //    Example = "A reasonable price",
            //    ExampleMeaning = "Giá cả hợp lý"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 208,
            //    Word = "Unable",
            //    Pronunciation = "əˈneɪbəl",
            //    Meaning = "Không thể",
            //    Example = "What is the man unable to do?",
            //    ExampleMeaning = "Người đàn ông không thể làm gì?"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 209,
            //    Word = "Delay",
            //    Pronunciation = "dɪˈleɪ",
            //    Meaning = "Trì hoãn",
            //    Example = "All flights have been delayed",
            //    ExampleMeaning = "Tất cả các chuyến bay đã bị trì hoãn"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 210,
            //    Word = "Legal",
            //    Pronunciation = "ˈligəl",
            //    Meaning = "Pháp lý",
            //    Example = "Legal advice",
            //    ExampleMeaning = "Tư vấn pháp lý"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 211,
            //    Word = "Regulation",
            //    Pronunciation = "ˌrɛgjəˈleɪʃən",
            //    Meaning = "Quy định",
            //    Example = "Under the regulations",
            //    ExampleMeaning = "Theo quy định"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 212,
            //    Word = "Expand",
            //    Pronunciation = "ɪkˈspænd",
            //    Meaning = "Mở rộng",
            //    Example = "Our business is expanding",
            //    ExampleMeaning = "Kinh doanh của chúng tôi đang mở rộng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 213,
            //    Word = "Launch",
            //    Pronunciation = "lɔnʧ",
            //    Meaning = "Phóng, ra mắt",
            //    Example = "The launch of a new product",
            //    ExampleMeaning = "Sự ra mắt của một sản phẩm mới"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 214,
            //    Word = "Recommendation",
            //    Pronunciation = "ˌrɛkəmənˈdeɪʃən",
            //    Meaning = "Sự giới thiệu",
            //    Example = "Letter of recommendation",
            //    ExampleMeaning = "Giấy giới thiệu"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 215,
            //    Word = "Direct",
            //    Pronunciation = "daɪˈrɛkt",
            //    Meaning = "Thẳng thắn",
            //    Example = "Please direct any questions to me",
            //    ExampleMeaning = "Vui lòng gửi câu hỏi cho tôi"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 216,
            //    Word = "Profit",
            //    Pronunciation = "ˈprɑfɪt",
            //    Meaning = "Lợi nhuận",
            //    Example = "Increase profits",
            //    ExampleMeaning = "Tăng lợi nhuận"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 217,
            //    Word = "Seek",
            //    Pronunciation = "sik",
            //    Meaning = "Tìm kiếm",
            //    Example = "Seek interns for the summer",
            //    ExampleMeaning = "Tìm kiếm thực tập cho mùa hè"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 218,
            //    Word = "Entry",
            //    Pronunciation = "ˈɛntri",
            //    Meaning = "Bài tham gia, Nhập cảnh",
            //    Example = "The winning entry",
            //    ExampleMeaning = "Các mục chiến thắng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 219,
            //    Word = "Claim",
            //    Pronunciation = "kleɪm",
            //    Meaning = "Yêu cầu",
            //    Example = "File a claim",
            //    ExampleMeaning = "Nộp một yêu cầu"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 220,
            //    Word = "Crew",
            //    Pronunciation = "kru",
            //    Meaning = "Nhóm, đội",
            //    Example = "A repair crew",
            //    ExampleMeaning = "Một đội sửa chữa"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 221,
            //    Word = "Demand",
            //    Pronunciation = "dɪˈmænd",
            //    Meaning = "Nhu cầu",
            //    Example = "Meet demand",
            //    ExampleMeaning = "Đáp ứng nhu cầu"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 222,
            //    Word = "Figure",
            //    Pronunciation = "ˈfɪgjər",
            //    Meaning = "Số liệu, Nhân vật",
            //    Example = "Sales figures",
            //    ExampleMeaning = "Số liệu bán hàng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 223,
            //    Word = "Raise",
            //    Pronunciation = "reɪz",
            //    Meaning = "Nâng cao, tăng",
            //    Example = "Raise money for charity",
            //    ExampleMeaning = "Quyên tiền cho tổ chức từ thiện"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 224,
            //    Word = "Attach",
            //    Pronunciation = "əˈtæʧ",
            //    Meaning = "Đính kèm",
            //    Example = "I have attached my resume",
            //    ExampleMeaning = "Tôi đã đính kèm sơ yếu lý lịch của tôi"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 225,
            //    Word = "Attract",
            //    Pronunciation = "əˈtrækt",
            //    Meaning = "Thu hút",
            //    Example = "A way of attracting customers",
            //    ExampleMeaning = "Cách thu hút khách hàng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 226,
            //    Word = "Insurance",
            //    Pronunciation = "ɪnˈʃʊrəns",
            //    Meaning = "Bảo hiểm",
            //    Example = "Provide health insurance for employees",
            //    ExampleMeaning = "Cung cấp bảo hiểm y tế cho nhân viên"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 227,
            //    Word = "Departure",
            //    Pronunciation = "dɪˈpɑrʧər",
            //    Meaning = "Khởi hành",
            //    Example = "The scheduled departure date",
            //    ExampleMeaning = "Ngày khởi hành dự kiến"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 228,
            //    Word = "Mayor",
            //    Pronunciation = "ˈmeɪər",
            //    Meaning = "Thị trưởng",
            //    Example = "The mayor of Tex town",
            //    ExampleMeaning = "Thị trưởng thành phố Tex"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 229,
            //    Word = "Balance",
            //    Pronunciation = "ˈbæləns",
            //    Meaning = "Cân đối",
            //    Example = "An account balance",
            //    ExampleMeaning = "Số dư tài khoản"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 230,
            //    Word = "Estimate",
            //    Pronunciation = "ˈɛstəmət",
            //    Meaning = "Ước tính, bản dự toán",
            //    Example = "An estimate for the project",
            //    ExampleMeaning = "Dự toán cho dự án"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 231,
            //    Word = "District",
            //    Pronunciation = "ˈdɪstrɪkt",
            //    Meaning = "Quận, khu",
            //    Example = "A commercial district",
            //    ExampleMeaning = "Khu thương mại"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 232,
            //    Word = "Former",
            //    Pronunciation = "ˈfɔrmər",
            //    Meaning = "Trước đây",
            //    Example = "A former employee",
            //    ExampleMeaning = "Một cựu nhân viên"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 233,
            //    Word = "Modern",
            //    Pronunciation = "ˈmɑdərn",
            //    Meaning = "Hiện đại",
            //    Example = "Design a modern building",
            //    ExampleMeaning = "Thiết kế một tòa nhà hiện đại"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 234,
            //    Word = "Tip",
            //    Pronunciation = "tɪp",
            //    Meaning = "Tiền boa",
            //    Example = "Tips on packing",
            //    ExampleMeaning = "Mẹo đóng gói"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 235,
            //    Word = "Establish",
            //    Pronunciation = "ɪˈstæblɪʃ",
            //    Meaning = "Thành lập",
            //    Example = "Established a business",
            //    ExampleMeaning = "Thành lập doanh nghiệp"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 236,
            //    Word = "Option",
            //    Pronunciation = "ˈɔpʃən",
            //    Meaning = "Tùy chọn",
            //    Example = "An option to change the date",
            //    ExampleMeaning = "Có thể thay đổi ngày"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 237,
            //    Word = "Retire",
            //    Pronunciation = "rɪˈtaɪr",
            //    Meaning = "Về hưu",
            //    Example = "Retire after 20 years of service",
            //    ExampleMeaning = "Nghỉ hưu sau 20 năm phục vụ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 238,
            //    Word = "Search",
            //    Pronunciation = "sɜrʧ",
            //    Meaning = "Tìm kiếm",
            //    Example = "The search for the next president",
            //    ExampleMeaning = "Việc tìm kiếm vị chủ tịch tiếp theo"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 239,
            //    Word = "Specific",
            //    Pronunciation = "spəˈsɪfɪk",
            //    Meaning = "Cụ thể",
            //    Example = "A specific example",
            //    ExampleMeaning = "Một ví dụ cụ thể"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 240,
            //    Word = "Agricultural",
            //    Pronunciation = "ægrɪˈkʌlʧərəl",
            //    Meaning = "Nông nghiệp",
            //    Example = "Agricultural technology",
            //    ExampleMeaning = "Công nghệ nông nghiệp"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 241,
            //    Word = "Historical",
            //    Pronunciation = "hɪˈstɔrɪkəl",
            //    Meaning = "Lịch sử",
            //    Example = "Historical figures",
            //    ExampleMeaning = "Nhân vật lịch sử"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 242,
            //    Word = "Helpful",
            //    Pronunciation = "ˈhɛlpfəl",
            //    Meaning = "Hữu ích",
            //    Example = "I hope you find this information helpful",
            //    ExampleMeaning = "Tôi hy vọng thông tin này hữu ích với bạn"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 243,
            //    Word = "Complaint",
            //    Pronunciation = "kəmˈpleɪnt",
            //    Meaning = "Lời phàn nàn",
            //    Example = "Complaints about the noise",
            //    ExampleMeaning = "Khiếu nại về tiếng ồn"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 244,
            //    Word = "Related",
            //    Pronunciation = "rɪˈleɪtɪd",
            //    Meaning = "Liên quan",
            //    Example = "Experience in a related field",
            //    ExampleMeaning = "Kinh nghiệm trong một lĩnh vực liên quan"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 245,
            //    Word = "Simply",
            //    Pronunciation = "ˈsɪmpli",
            //    Meaning = "Đơn giản",
            //    Example = "Simply fill out the form below",
            //    ExampleMeaning = "Chỉ cần điền vào mẫu đơn bên dưới"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 246,
            //    Word = "Unique",
            //    Pronunciation = "juˈnik",
            //    Meaning = "Độc nhất",
            //    Example = "Offer a unique opportunity",
            //    ExampleMeaning = "Cung cấp một cơ hội duy nhất"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 247,
            //    Word = "Concerning",
            //    Pronunciation = "kənˈsɜrnɪŋ",
            //    Meaning = "Liên quan",
            //    Example = "Any questions concerning the order",
            //    ExampleMeaning = "Mọi thắc mắc liên quan đến đơn hàng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 248,
            //    Word = "Reputation",
            //    Pronunciation = "ˌrɛpjəˈteɪʃən",
            //    Meaning = "Uy tín",
            //    Example = "A well-deserved reputation",
            //    ExampleMeaning = "Một danh tiếng xứng đáng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 249,
            //    Word = "Ability",
            //    Pronunciation = "əˈbɪləti",
            //    Meaning = "Có khả năng",
            //    Example = "Ability to speak three languages",
            //    ExampleMeaning = "Khả năng nói ba ngôn ngữ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 250,
            //    Word = "Arrival",
            //    Pronunciation = "əˈraɪvəl",
            //    Meaning = "Đến",
            //    Example = "The time of arrival",
            //    ExampleMeaning = "Thời điểm đến"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 251,
            //    Word = "Familiar",
            //    Pronunciation = "fəˈmɪljər",
            //    Meaning = "Quen",
            //    Example = "I am familiar with the area",
            //    ExampleMeaning = "Tôi quen thuộc với khu vực"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 252,
            //    Word = "Ideal",
            //    Pronunciation = "aɪˈdil",
            //    Meaning = "Lý tưởng",
            //    Example = "In ideal location",
            //    ExampleMeaning = "Ở vị trí lý tưởng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 253,
            //    Word = "Maintain",
            //    Pronunciation = "meɪnˈteɪn",
            //    Meaning = "Duy trì",
            //    Example = "Maintain website",
            //    ExampleMeaning = "Duy trì trang web"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 254,
            //    Word = "Landscaping",
            //    Pronunciation = "ˈlændˌskeɪpɪŋ",
            //    Meaning = "Cảnh quan",
            //    Example = "A landscaping company",
            //    ExampleMeaning = "Một công ty trang trí cảnh quan sân vườn"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 255,
            //    Word = "Organize",
            //    Pronunciation = "ˈɔrgəˌnaɪz",
            //    Meaning = "Tổ chức",
            //    Example = "Organize an event",
            //    ExampleMeaning = "Tổ chức một sự kiện"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 256,
            //    Word = "Significant",
            //    Pronunciation = "sɪgˈnɪfɪkənt",
            //    Meaning = "Có ý nghĩa",
            //    Example = "A significant increase in profits",
            //    ExampleMeaning = "Lợi nhuận tăng đáng kể"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 257,
            //    Word = "Occasion",
            //    Pronunciation = "əˈkeɪʒən",
            //    Meaning = "Dịp",
            //    Example = "A special occasion",
            //    ExampleMeaning = "Một dịp đặc biệt"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 258,
            //    Word = "Standard",
            //    Pronunciation = "ˈstændərd",
            //    Meaning = "Tiêu chuẩn",
            //    Example = "Safety standards",
            //    ExampleMeaning = "Tiêu chuẩn an toàn"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 259,
            //    Word = "Background",
            //    Pronunciation = "ˈbækˌgraʊnd",
            //    Meaning = "Lý lịch",
            //    Example = "An impressive educational background",
            //    ExampleMeaning = "Một nền tảng giáo dục ấn tượng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 260,
            //    Word = "Guided",
            //    Pronunciation = "ˈgaɪdɪd",
            //    Meaning = "Hướng dẫn",
            //    Example = "A guided tour",
            //    ExampleMeaning = "Một tour du lịch có hướng dẫn"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 261,
            //    Word = "Advanced",
            //    Pronunciation = "ədˈvænst",
            //    Meaning = "Nâng cao",
            //    Example = "Advanced technology",
            //    ExampleMeaning = "Công nghệ tiên tiến"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 262,
            //    Word = "Alternative",
            //    Pronunciation = "ɔlˈtɜrnətɪv",
            //    Meaning = "Thay thế",
            //    Example = "An alternative date",
            //    ExampleMeaning = "Một ngày khác"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 263,
            //    Word = "Confident",
            //    Pronunciation = "ˈkɑnfədənt",
            //    Meaning = "Tự tin",
            //    Example = "I'm confident I can do it",
            //    ExampleMeaning = "Tôi tự tin tôi có thể làm được"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 264,
            //    Word = "Decade",
            //    Pronunciation = "ˈdɛkeɪd",
            //    Meaning = "Thập kỷ",
            //    Example = "Over the past two decades",
            //    ExampleMeaning = "Trong hai thập kỷ qua"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 265,
            //    Word = "Initial",
            //    Pronunciation = "ɪˈnɪʃəl",
            //    Meaning = "Ban đầu",
            //    Example = "Attend the initial training session",
            //    ExampleMeaning = "Tham dự buổi đào tạo ban đầu"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 266,
            //    Word = "Separate",
            //    Pronunciation = "ˈsɛprət",
            //    Meaning = "Tách rời",
            //    Example = "My order arrived in two separate shipments",
            //    ExampleMeaning = "Đơn hàng của tôi đến trong hai lô hàng riêng biệt"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 267,
            //    Word = "Celebration",
            //    Pronunciation = "ˌsɛləˈbreɪʃən",
            //    Meaning = "Lễ kỷ niệm",
            //    Example = "The grand opening celebration",
            //    ExampleMeaning = "Lễ khai trương"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 268,
            //    Word = "Concern",
            //    Pronunciation = "kənˈsɜrn",
            //    Meaning = "Mối quan ngại",
            //    Example = "Express concern",
            //    ExampleMeaning = "Thể hiện sự quan tâm"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 269,
            //    Word = "Environment",
            //    Pronunciation = "ɪnˈvaɪrənmənt",
            //    Meaning = "Môi trường",
            //    Example = "Work environment",
            //    ExampleMeaning = "Môi trường làm việc"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 270,
            //    Word = "Operate",
            //    Pronunciation = "ˈɔpəˌreɪt",
            //    Meaning = "Vận hành",
            //    Example = "Operate a machine safely",
            //    ExampleMeaning = "Vận hành máy an toàn"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 271,
            //    Word = "Various",
            //    Pronunciation = "ˈvɛriəs",
            //    Meaning = "Khác nhau",
            //    Example = "Various designs and patterns",
            //    ExampleMeaning = "Các thiết kế và mẫu đa dạng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 272,
            //    Word = "Brief",
            //    Pronunciation = "brif",
            //    Meaning = "Tóm tắt",
            //    Example = "A brief report",
            //    ExampleMeaning = "Một báo cáo ngắn gọn"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 273,
            //    Word = "Full-time",
            //    Pronunciation = "fʊl-taɪm",
            //    Meaning = "Toàn thời gian",
            //    Example = "Full-time employees",
            //    ExampleMeaning = "Nhân viên toàn thời gian"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 274,
            //    Word = "Overall",
            //    Pronunciation = "ˈoʊvərˌrɔl",
            //    Meaning = "Nhìn chung",
            //    Example = "The overall budget",
            //    ExampleMeaning = "Ngân sách tổng thể"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 275,
            //    Word = "Achieve",
            //    Pronunciation = "əˈʧiv",
            //    Meaning = "Hoàn thành",
            //    Example = "Achieve a sales target",
            //    ExampleMeaning = "Đạt được mục tiêu bán hàng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 276,
            //    Word = "Basis",
            //    Pronunciation = "ˈbeɪsɪs",
            //    Meaning = "Nền tảng",
            //    Example = "Pay on a monthly basis",
            //    ExampleMeaning = "Thanh toán hàng tháng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 277,
            //    Word = "Complex",
            //    Pronunciation = "kəmˈplɛks",
            //    Meaning = "Khu phức hợp",
            //    Example = "A sports complex",
            //    ExampleMeaning = "Khu phức hợp thể thao"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 278,
            //    Word = "Delighted",
            //    Pronunciation = "dɪˈlaɪtɪd",
            //    Meaning = "Vui mừng",
            //    Example = "We are delighted to see you",
            //    ExampleMeaning = "Chúng tôi rất vui được gặp bạn"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 279,
            //    Word = "Obtain",
            //    Pronunciation = "əbˈteɪn",
            //    Meaning = "Đạt được",
            //    Example = "Obtain information from the internet",
            //    ExampleMeaning = "Lấy thông tin từ internet"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 280,
            //    Word = "Honor",
            //    Pronunciation = "ˈɑnər",
            //    Meaning = "Tôn vinh",
            //    Example = "Honor an employee",
            //    ExampleMeaning = "Tôn vinh một nhân viên"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 281,
            //    Word = "Properly",
            //    Pronunciation = "ˈprɑpərli",
            //    Meaning = "Đúng, phù hợp",
            //    Example = "Properly trained staff",
            //    ExampleMeaning = "Nhân viên được đào tạo đúng cách"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 282,
            //    Word = "Suitable",
            //    Pronunciation = "ˈsutəbəl",
            //    Meaning = "Thích hợp",
            //    Example = "Suitable for outdoor use",
            //    ExampleMeaning = "Thích hợp cho sử dụng ngoài trời"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 283,
            //    Word = "Electronic",
            //    Pronunciation = "ɪˌlɛkˈtrɑnɪk",
            //    Meaning = "Điện tử",
            //    Example = "Personal electronic devices",
            //    ExampleMeaning = "Thiết bị điện tử cá nhân"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 284,
            //    Word = "Finalize",
            //    Pronunciation = "ˈfaɪnəˌlaɪz",
            //    Meaning = "Hoàn thiện",
            //    Example = "Finalize a contract",
            //    ExampleMeaning = "Hoàn thiện, kí kết hợp đồng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 285,
            //    Word = "Generous",
            //    Pronunciation = "ˈʤɛnərəs",
            //    Meaning = "Hào phóng",
            //    Example = "Generous donation to a charity",
            //    ExampleMeaning = "Sự quyên góp hào phóng cho một tổ chức từ thiện"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 286,
            //    Word = "Preparation",
            //    Pronunciation = "ˌprɛpəˈreɪʃən",
            //    Meaning = "Chuẩn bị",
            //    Example = "In preparation for an event",
            //    ExampleMeaning = "Để chuẩn bị cho một sự kiện"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 287,
            //    Word = "Duty",
            //    Pronunciation = "ˈdjuti",
            //    Meaning = "Nhiệm vụ",
            //    Example = "Main duties of a teacher",
            //    ExampleMeaning = "Nhiệm vụ chính của giáo viên"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 288,
            //    Word = "Earn",
            //    Pronunciation = "ɜrn",
            //    Meaning = "Kiếm",
            //    Example = "Earn the respect of people",
            //    ExampleMeaning = "Có được sự tôn trọng của mọi người"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 289,
            //    Word = "Willing",
            //    Pronunciation = "ˈwɪlɪŋ",
            //    Meaning = "Sẵn lòng",
            //    Example = "I am willing to work overseas",
            //    ExampleMeaning = "Tôi sẵn sàng làm việc ở nước ngoài"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 290,
            //    Word = "Worth",
            //    Pronunciation = "wɜrθ",
            //    Meaning = "Đáng giá",
            //    Example = "The book is worth reading",
            //    ExampleMeaning = "Cuốn sách đáng đọc"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 291,
            //    Word = "Fund",
            //    Pronunciation = "fʌnd",
            //    Meaning = "Quỹ, tài trợ",
            //    Example = "A project funded by the government",
            //    ExampleMeaning = "Một dự án được tài trợ bởi chính phủ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 292,
            //    Word = "Overnight",
            //    Pronunciation = "ˈoʊvərˈnaɪt",
            //    Meaning = "Qua đêm",
            //    Example = "Free overnight delivery",
            //    ExampleMeaning = "Giao hàng qua đêm miễn phí"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 293,
            //    Word = "Particularly",
            //    Pronunciation = "pərˈtɪkjələrli",
            //    Meaning = "Đặc biệt",
            //    Example = "Particularly interested in history",
            //    ExampleMeaning = "Đặc biệt quan tâm đến lịch sử"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 294,
            //    Word = "Aspect",
            //    Pronunciation = "ˈæˌspɛkt",
            //    Meaning = "Khía cạnh",
            //    Example = "Every aspect of a project",
            //    ExampleMeaning = "Mọi khía cạnh của một dự án"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 295,
            //    Word = "Hesitate",
            //    Pronunciation = "ˈhɛzəˌteɪt",
            //    Meaning = "Do dự",
            //    Example = "Please do not hesitate to contact us",
            //    ExampleMeaning = "Xin vui lòng liên hệ với chúng tôi"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 296,
            //    Word = "Involved",
            //    Pronunciation = "ɪnˈvɑlvd",
            //    Meaning = "Có tính liên quan",
            //    Example = "I was not involved with the project",
            //    ExampleMeaning = "Tôi đã không tham gia vào dự án"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 297,
            //    Word = "Regularly",
            //    Pronunciation = "ˈrɛgjələrli",
            //    Meaning = "Thường xuyên",
            //    Example = "A regularly updated list",
            //    ExampleMeaning = "Một danh sách được cập nhật thường xuyên"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 298,
            //    Word = "Scholarship",
            //    Pronunciation = "ˈskɑlərˌʃɪp",
            //    Meaning = "Học bổng",
            //    Example = "Apply for a scholarship",
            //    ExampleMeaning = "Xin học bổng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 299,
            //    Word = "Shortly",
            //    Pronunciation = "ˈʃɔrtli",
            //    Meaning = "Một thời gian ngắn",
            //    Example = "The meeting will begin shortly",
            //    ExampleMeaning = "Cuộc họp sẽ bắt đầu trong ít phút"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 300,
            //    Word = "Automobile",
            //    Pronunciation = "ˈɔtəmoʊˌbil",
            //    Meaning = "Ô tô",
            //    Example = "Automobile manufacturing",
            //    ExampleMeaning = "Sản xuất ô tô"
            //});
            //#endregion

            //#region 301-400
            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 301,
            //    Word = "Deposit",
            //    Pronunciation = "dɪˈpɑzət",
            //    Meaning = "Tiền gửi",
            //    Example = "A security deposit",
            //    ExampleMeaning = "Tiền gửi đảm bảo"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 302,
            //    Word = "Contain",
            //    Pronunciation = "kənˈteɪn",
            //    Meaning = "Chứa",
            //    Example = "The book contains useful information",
            //    ExampleMeaning = "Cuốn sách bao gồm thông tin hữu ích"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 303,
            //    Word = "Content",
            //    Pronunciation = "ˈkɑntɛnt",
            //    Meaning = "Nội dung",
            //    Example = "The contents of the book",
            //    ExampleMeaning = "Nội dung của cuốn sách"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 304,
            //    Word = "Proof",
            //    Pronunciation = "pruf",
            //    Meaning = "Bằng chứng",
            //    Example = "Proof of purchase",
            //    ExampleMeaning = "Bằng chứng mua hàng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 305,
            //    Word = "Affect",
            //    Pronunciation = "əˈfɛkt",
            //    Meaning = "Có ảnh hưởng đến",
            //    Example = "Affect the price",
            //    ExampleMeaning = "Ảnh hưởng đến giá cả"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 306,
            //    Word = "Recognize",
            //    Pronunciation = "ˈrɛkəgˌnaɪz",
            //    Meaning = "Nhìn nhận",
            //    Example = "Our products are recognized for their quality",
            //    ExampleMeaning = "Sản phẩm của chúng tôi nổi tiếng về chất lượng."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 307,
            //    Word = "Represent",
            //    Pronunciation = "ˌrɛprɪˈzɛnt",
            //    Meaning = "Đại diện",
            //    Example = "Represent the company",
            //    ExampleMeaning = "Đại diện công ty"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 308,
            //    Word = "Transfer",
            //    Pronunciation = "ˈtrænsfər",
            //    Meaning = "Chuyển khoản",
            //    Example = "Tex was transferred to Alaska",
            //    ExampleMeaning = "Ông Tex đã được chuyển đến Alaska"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 309,
            //    Word = "Anniversary",
            //    Pronunciation = "ˌænəˈvɜrsəri",
            //    Meaning = "Ngày kỷ niệm",
            //    Example = "Celebrate the 20th anniversary",
            //    ExampleMeaning = "Kỷ niệm 20 năm"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 310,
            //    Word = "Automatically",
            //    Pronunciation = "ˌɔtəˈmætɪkli",
            //    Meaning = "Tự động",
            //    Example = "The machine will automatically shut down",
            //    ExampleMeaning = "Máy sẽ tự động tắt"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 311,
            //    Word = "Capacity",
            //    Pronunciation = "kəˈpæsɪti",
            //    Meaning = "Sức chứa",
            //    Example = "Production capacity",
            //    ExampleMeaning = "Sản lượng sản xuất"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 312,
            //    Word = "Destination",
            //    Pronunciation = "ˌdɛstɪˈneɪʃən",
            //    Meaning = "Nơi Đến",
            //    Example = "Travel destinations",
            //    ExampleMeaning = "Điểm du lịch"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 313,
            //    Word = "Grant",
            //    Pronunciation = "grænt",
            //    Meaning = "Ban cho, cấp vốn",
            //    Example = "Obtain a grant",
            //    ExampleMeaning = "Nhận được một khoản trợ cấp"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 314,
            //    Word = "Publish",
            //    Pronunciation = "ˈpʌblɪʃ",
            //    Meaning = "Công bố, xuất bản",
            //    Example = "Publish a magazine",
            //    ExampleMeaning = "Xuất bản một tạp chí"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 315,
            //    Word = "Accompany",
            //    Pronunciation = "əˈkʌmpəni",
            //    Meaning = "Đồng hành",
            //    Example = "The book is accompanied by a CD",
            //    ExampleMeaning = "Cuốn sách được kèm theo một đĩa CD"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 316,
            //    Word = "Economic",
            //    Pronunciation = "ˌikəˈnɑmɪk",
            //    Meaning = "Thuộc kinh tế",
            //    Example = "Economic growth",
            //    ExampleMeaning = "Tăng trưởng kinh tế"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 317,
            //    Word = "Extremely",
            //    Pronunciation = "ɛkˈstrimli",
            //    Meaning = "Cực kì",
            //    Example = "Check extremely carefully",
            //    ExampleMeaning = "Kiểm tra cực kỳ cẩn thận"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 318,
            //    Word = "Institution",
            //    Pronunciation = "ˌɪnstɪˈtuʃən",
            //    Meaning = "Tổ chức giáo dục",
            //    Example = "A financial institution",
            //    ExampleMeaning = "Một tổ chức tài chính"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 319,
            //    Word = "Accurate",
            //    Pronunciation = "ˈækjərət",
            //    Meaning = "Chính xác",
            //    Example = "Accurate sales figures",
            //    ExampleMeaning = "Số liệu bán hàng chính xác"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 320,
            //    Word = "Compete",
            //    Pronunciation = "kəmˈpit",
            //    Meaning = "Tranh đua",
            //    Example = "Compete with large companies",
            //    ExampleMeaning = "Cạnh tranh với các công ty lớn"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 321,
            //    Word = "Emphasize",
            //    Pronunciation = "ˈɛmfəˌsaɪz",
            //    Meaning = "Nhấn mạnh",
            //    Example = "Emphasize a point",
            //    ExampleMeaning = "Nhấn mạnh một điểm"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 322,
            //    Word = "Aware",
            //    Pronunciation = "əˈwɛr",
            //    Meaning = "Nhận thức được",
            //    Example = "I was aware of the problem",
            //    ExampleMeaning = "Tôi nhận thức được vấn đề"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 323,
            //    Word = "Crowded",
            //    Pronunciation = "ˈkraʊdɪd",
            //    Meaning = "Đông người",
            //    Example = "The town is crowded with tourists.",
            //    ExampleMeaning = "Thị trấn rất đông khách du lịch."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 324,
            //    Word = "Praise",
            //    Pronunciation = "preɪz",
            //    Meaning = "Khen ngợi",
            //    Example = "The team was praised by the CEO.",
            //    ExampleMeaning = "Nhóm đã được CEO khen ngợi."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 325,
            //    Word = "Valuable",
            //    Pronunciation = "ˈvæljəbəl",
            //    Meaning = "Quý giá",
            //    Example = "A valuable addition to the team.",
            //    ExampleMeaning = "Một bổ sung có giá trị cho đội."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 326,
            //    Word = "Explore",
            //    Pronunciation = "ɪkˈsplɔr",
            //    Meaning = "Khám phá",
            //    Example = "Explore a possibility.",
            //    ExampleMeaning = "Suy xét về một khả năng."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 327,
            //    Word = "Found",
            //    Pronunciation = "faʊnd",
            //    Meaning = "Thành lập (V nguyên mẫu)",
            //    Example = "Found a company.",
            //    ExampleMeaning = "Thành lập một công ty."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 328,
            //    Word = "Function",
            //    Pronunciation = "ˈfʌŋkʃən",
            //    Meaning = "Chức năng",
            //    Example = "Basic functions.",
            //    ExampleMeaning = "Chức năng cơ bản."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 329,
            //    Word = "Impact",
            //    Pronunciation = "ˈɪmpækt",
            //    Meaning = "Va chạm",
            //    Example = "Have a negative impact on the environment.",
            //    ExampleMeaning = "Có tác động tiêu cực đến môi trường."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 330,
            //    Word = "Amazing",
            //    Pronunciation = "əˈmeɪzɪŋ",
            //    Meaning = "Kinh ngạc",
            //    Example = "An amazing success.",
            //    ExampleMeaning = "Thành công đáng kinh ngạc."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 331,
            //    Word = "Assure",
            //    Pronunciation = "əˈʃʊr",
            //    Meaning = "Traấn an",
            //    Example = "Assure Tex that he will be promoted.",
            //    ExampleMeaning = "Đảm bảo với Tex rằng anh ta sẽ được thăng chức."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 332,
            //    Word = "Cooperation",
            //    Pronunciation = "koʊˌɑpəˈreɪʃən",
            //    Meaning = "Hợp tác",
            //    Example = "Thank you for your cooperation.",
            //    ExampleMeaning = "Cảm ơn sự hợp tác của bạn."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 333,
            //    Word = "Popularity",
            //    Pronunciation = "ˌpɑpjəˈlɛrəti",
            //    Meaning = "Phổ biến",
            //    Example = "A rise in popularity.",
            //    ExampleMeaning = "Sự nổi tiếng ngày càng tăng."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 334,
            //    Word = "Permit",
            //    Pronunciation = "pərˈmɪt",
            //    Meaning = "Giấy phép",
            //    Example = "A construction permit.",
            //    ExampleMeaning = "Giấy phép xây dựng."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 335,
            //    Word = "Solve",
            //    Pronunciation = "sɑlv",
            //    Meaning = "Gỡ rối",
            //    Example = "Solve a problem.",
            //    ExampleMeaning = "Giải quyết vấn đề."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 336,
            //    Word = "Vote",
            //    Pronunciation = "voʊt",
            //    Meaning = "Bỏ phiếu",
            //    Example = "Vote against the proposal.",
            //    ExampleMeaning = "Bỏ phiếu chống lại đề xuất."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 337,
            //    Word = "Crop",
            //    Pronunciation = "krɑp",
            //    Meaning = "Mùa vụ",
            //    Example = "Locally grown crops.",
            //    ExampleMeaning = "Mùa màng địa phương."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 338,
            //    Word = "Neighborhood",
            //    Pronunciation = "ˈneɪbərˌhʊd",
            //    Meaning = "Khu vực lân cận",
            //    Example = "There are no hotels in this neighborhood.",
            //    ExampleMeaning = "Không có khách sạn trong khu phố này."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 339,
            //    Word = "Permanent",
            //    Pronunciation = "ˈpɜrmənənt",
            //    Meaning = "Dài hạn",
            //    Example = "The permanent exhibit.",
            //    ExampleMeaning = "Hiện vật triễn lãm vĩnh viễn."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 340,
            //    Word = "Regret",
            //    Pronunciation = "rəˈgrɛt",
            //    Meaning = "Hối tiếc",
            //    Example = "We regret to inform you that...",
            //    ExampleMeaning = "Chúng tôi rất tiếc phải thông báo cho bạn rằng..."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 341,
            //    Word = "Slightly",
            //    Pronunciation = "ˈslaɪtli",
            //    Meaning = "Ít",
            //    Example = "Slightly increased from 24 to 27 percent.",
            //    ExampleMeaning = "Tăng nhẹ từ 24 đến 27 percent."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 342,
            //    Word = "Complicated",
            //    Pronunciation = "ˈkɑmpləˌkeɪtəd",
            //    Meaning = "Phức tạp",
            //    Example = "The system is very complicated.",
            //    ExampleMeaning = "Hệ thống rất phức tạp."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 343,
            //    Word = "Factor",
            //    Pronunciation = "ˈfæktər",
            //    Meaning = "Hệ số, yếu tố",
            //    Example = "Various factors.",
            //    ExampleMeaning = "Các yếu tố khác nhau."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 344,
            //    Word = "Favorable",
            //    Pronunciation = "ˈfeɪvərəbəl",
            //    Meaning = "Thuận lợi",
            //    Example = "Favorable customer reviews.",
            //    ExampleMeaning = "Đánh giá tốt từ phía khách hàng."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 345,
            //    Word = "Guarantee",
            //    Pronunciation = "ˌgɛrənˈti",
            //    Meaning = "Bảo hành",
            //    Example = "Guarantee same-day delivery.",
            //    ExampleMeaning = "Đảm bảo giao hàng trong ngày."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 346,
            //    Word = "Mechanical",
            //    Pronunciation = "məˈkænɪkəl",
            //    Meaning = "Cơ khí",
            //    Example = "Due to mechanical trouble.",
            //    ExampleMeaning = "Do sự cố máy móc."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 347,
            //    Word = "Priority",
            //    Pronunciation = "praɪˈɔrəti",
            //    Meaning = "Sự ưu tiên",
            //    Example = "A high priority.",
            //    ExampleMeaning = "Ưu tiên cao."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 348,
            //    Word = "Relatively",
            //    Pronunciation = "ˈrɛlətɪvli",
            //    Meaning = "Tương đối",
            //    Example = "Relatively recent trend",
            //    ExampleMeaning = "Xu hướng tương đối mới"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 349,
            //    Word = "Resource",
            //    Pronunciation = "ˈrisɔrs",
            //    Meaning = "Nguồn",
            //    Example = "Water is an important natural resource",
            //    ExampleMeaning = "Nước là nguồn tài nguyên thiên nhiên quan trọng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 350,
            //    Word = "Shuttle",
            //    Pronunciation = "ˈʃʌtəl",
            //    Meaning = "Phương tiện đưa đón",
            //    Example = "Free shuttle service",
            //    ExampleMeaning = "Dịch vụ đưa đón miễn phí"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 351,
            //    Word = "Divide",
            //    Pronunciation = "dɪˈvaɪd",
            //    Meaning = "Chia ra",
            //    Example = "The catalog is divided into three sections",
            //    ExampleMeaning = "Danh mục được chia thành ba phần"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 352,
            //    Word = "Native",
            //    Pronunciation = "ˈneɪtɪv",
            //    Meaning = "Tự nhiên, gốc gác",
            //    Example = "A singer native to the town",
            //    ExampleMeaning = "Một ca sĩ quê ở thị trấn (này)."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 353,
            //    Word = "Afford",
            //    Pronunciation = "əˈfɔrd",
            //    Meaning = "Có khả năng mua, chi tiêu",
            //    Example = "We can't afford to do that",
            //    ExampleMeaning = "Chúng ta không thể làm vậy được"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 354,
            //    Word = "Income",
            //    Pronunciation = "ˈɪnˌkʌm",
            //    Meaning = "Thu nhập",
            //    Example = "High income",
            //    ExampleMeaning = "Thu nhập cao"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 355,
            //    Word = "Occur",
            //    Pronunciation = "əˈkɜr",
            //    Meaning = "Xảy ra",
            //    Example = "Damage occurred during shipment",
            //    ExampleMeaning = "Thiệt hại xảy ra trong quá trình vận chuyển"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 356,
            //    Word = "Saving",
            //    Pronunciation = "ˈseɪvɪŋ",
            //    Meaning = "Tiết kiệm",
            //    Example = "Significant savings",
            //    ExampleMeaning = "Tiết kiệm đáng kể"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 357,
            //    Word = "Findings",
            //    Pronunciation = "ˈfaɪndɪŋz",
            //    Meaning = "Kết quả",
            //    Example = "Research findings",
            //    ExampleMeaning = "Kết quả nghiên cứu"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 358,
            //    Word = "Locate",
            //    Pronunciation = "ˈloʊˌkeɪt",
            //    Meaning = "Định vị",
            //    Example = "I was unable to locate the book",
            //    ExampleMeaning = "Tôi không thể xác định vị trí cuốn sách"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 359,
            //    Word = "Postpone",
            //    Pronunciation = "poʊˈspoʊn",
            //    Meaning = "Trì hoãn",
            //    Example = "Postpone a meeting",
            //    ExampleMeaning = "Trì hoãn một cuộc họp"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 360,
            //    Word = "Preserve",
            //    Pronunciation = "prɪˈzɜrv",
            //    Meaning = "Bảo quản",
            //    Example = "Preserve the environment",
            //    ExampleMeaning = "Giữ gìn môi trường"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 361,
            //    Word = "Prove",
            //    Pronunciation = "pruv",
            //    Meaning = "Chứng minh",
            //    Example = "Prove to be difficult",
            //    ExampleMeaning = "(Chủ ngữ) mang tính thử thách."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 362,
            //    Word = "Exact",
            //    Pronunciation = "ɪgˈzækt",
            //    Meaning = "Chính xác",
            //    Example = "I can't remember the exact date",
            //    ExampleMeaning = "Tôi không thể nhớ ngày chính xác"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 363,
            //    Word = "Gain",
            //    Pronunciation = "geɪn",
            //    Meaning = "Thu được",
            //    Example = "Gain popularity",
            //    ExampleMeaning = "Trở nên phổ biến"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 364,
            //    Word = "Labor",
            //    Pronunciation = "ˈleɪbər",
            //    Meaning = "Lao động",
            //    Example = "Labor cost",
            //    ExampleMeaning = "Chi phí nhân công"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 365,
            //    Word = "Regard",
            //    Pronunciation = "rɪˈgɑrd",
            //    Meaning = "Trân trọng, lời thăm hỏi",
            //    Example = "Be widely regarded as",
            //    ExampleMeaning = "Được nhiều người coi là"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 366,
            //    Word = "Closely",
            //    Pronunciation = "ˈkloʊsli",
            //    Meaning = "Gần gũi, kĩ càng",
            //    Example = "Work closely with local businesses",
            //    ExampleMeaning = "Hợp tác chặt chẽ với các doanh nghiệp địa phương"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 367,
            //    Word = "Deserve",
            //    Pronunciation = "dɪˈzɜrv",
            //    Meaning = "Xứng đáng",
            //    Example = "Deserve a promotion",
            //    ExampleMeaning = "Xứng đáng được thăng chức"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 368,
            //    Word = "Identify",
            //    Pronunciation = "aɪˈdɛnəˌfaɪ",
            //    Meaning = "Nhận định",
            //    Example = "Identify problems",
            //    ExampleMeaning = "Xác định vấn đề"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 369,
            //    Word = "Loyal",
            //    Pronunciation = "ˈlɔɪəl",
            //    Meaning = "Trung thành",
            //    Example = "Loyal customers",
            //    ExampleMeaning = "Khách hàng thân thiết"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 370,
            //    Word = "Promising",
            //    Pronunciation = "ˈprɑməsɪŋ",
            //    Meaning = "Hứa hẹn, tiềm năng",
            //    Example = "The most promising applicant",
            //    ExampleMeaning = "Ứng viên triển vọng nhất"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 371,
            //    Word = "Stress",
            //    Pronunciation = "strɛs",
            //    Meaning = "Nhấn mạnh",
            //    Example = "Stress the importance of reading",
            //    ExampleMeaning = "Nhấn mạnh tầm quan trọng của việc đọc"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 372,
            //    Word = "Analyze",
            //    Pronunciation = "ˈænəˌlaɪz",
            //    Meaning = "Phân tích",
            //    Example = "Analyze customer feedback",
            //    ExampleMeaning = "Phân tích phản hồi của khách hàng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 373,
            //    Word = "Commission",
            //    Pronunciation = "kəˈmɪʃən",
            //    Meaning = "Uỷ ban, giao việc",
            //    Example = "The report was commissioned by Tex Corporation.",
            //    ExampleMeaning = "Báo cáo được ủy quyền bởi Tex Corporation."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 374,
            //    Word = "Committed",
            //    Pronunciation = "kəˈmɪtəd",
            //    Meaning = "Cam kết",
            //    Example = "We are committed to providing quality service.",
            //    ExampleMeaning = "Chúng tôi cam kết cung cấp dịch vụ chất lượng."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 375,
            //    Word = "Comparison",
            //    Pronunciation = "kəmˈpɛrəsən",
            //    Meaning = "So sánh",
            //    Example = "A cost comparison.",
            //    ExampleMeaning = "So sánh chi phí."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 376,
            //    Word = "Component",
            //    Pronunciation = "kəmˈpoʊnənt",
            //    Meaning = "Thành phần",
            //    Example = "Electronic components.",
            //    ExampleMeaning = "Linh kiện điện tử."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 377,
            //    Word = "Enable",
            //    Pronunciation = "ɛˈneɪbəl",
            //    Meaning = "Kích hoạt",
            //    Example = "Enable staff to work from home.",
            //    ExampleMeaning = "Cho phép nhân viên làm việc tại nhà."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 378,
            //    Word = "Enjoyable",
            //    Pronunciation = "ɛnˈʤɔɪəbəl",
            //    Meaning = "Có thể thưởng thức",
            //    Example = "An enjoyable stay at a hotel.",
            //    ExampleMeaning = "Một kỳ nghỉ thú vị tại khách sạn."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 379,
            //    Word = "Existing",
            //    Pronunciation = "ɪgˈzɪstɪŋ",
            //    Meaning = "Hiện tại",
            //    Example = "Existing customers.",
            //    ExampleMeaning = "Khách hàng hiện tại."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 380,
            //    Word = "Flyer",
            //    Pronunciation = "ˈflaɪər",
            //    Meaning = "Tờ rơi",
            //    Example = "Post a flyer.",
            //    ExampleMeaning = "Gửi một tờ rơi."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 381,
            //    Word = "Proceed",
            //    Pronunciation = "proʊˈsid",
            //    Meaning = "Tiến hành",
            //    Example = "Proceed to the boarding gate.",
            //    ExampleMeaning = "Tiếp tục đến cổng lên máy bay."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 382,
            //    Word = "Prevent",
            //    Pronunciation = "prɪˈvɛnt",
            //    Meaning = "Ngăn chặn",
            //    Example = "Tex prevented us from entering the room.",
            //    ExampleMeaning = "Tex ngăn chúng tôi vào phòng."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 383,
            //    Word = "Alike",
            //    Pronunciation = "əˈlaɪk",
            //    Meaning = "Như nhau",
            //    Example = "Teachers and students alike.",
            //    ExampleMeaning = "Giáo viên và học sinh cũng vậy."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 384,
            //    Word = "Appoint",
            //    Pronunciation = "əˈpɔɪnt",
            //    Meaning = "Bổ nhiệm",
            //    Example = "I was appointed chairperson of the committee.",
            //    ExampleMeaning = "Tôi được bổ nhiệm làm chủ tịch ủy ban."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 385,
            //    Word = "Connection",
            //    Pronunciation = "kəˈnɛkʃən",
            //    Meaning = "Kết nối",
            //    Example = "A high-speed internet connection.",
            //    ExampleMeaning = "Kết nối internet tốc độ cao."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 386,
            //    Word = "Eager",
            //    Pronunciation = "ˈigər",
            //    Meaning = "Hăng hái",
            //    Example = "I am eager to learn new things.",
            //    ExampleMeaning = "Tôi háo hức học hỏi những điều mới."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 387,
            //    Word = "Ease",
            //    Pronunciation = "iz",
            //    Meaning = "Giảm bớt",
            //    Example = "Ease of use.",
            //    ExampleMeaning = "Dễ sử dụng."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 388,
            //    Word = "Fairly",
            //    Pronunciation = "ˈfɛrli",
            //    Meaning = "Công bằng, tương đối",
            //    Example = "Fairly common.",
            //    ExampleMeaning = "Khá phổ biến."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 389,
            //    Word = "Absolutely",
            //    Pronunciation = "ˌæbsəˈlutli",
            //    Meaning = "Chắc chắn",
            //    Example = "Absolutely free of charge.",
            //    ExampleMeaning = "Hoàn toàn miễn phí."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 390,
            //    Word = "Atmosphere",
            //    Pronunciation = "ˈætməˌsfɪr",
            //    Meaning = "Không khí",
            //    Example = "A warm atmosphere.",
            //    ExampleMeaning = "Một bầu không khí ấm áp."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 391,
            //    Word = "Calculate",
            //    Pronunciation = "ˈkælkjəˌleɪt",
            //    Meaning = "Tính toán",
            //    Example = "Calculate delivery costs.",
            //    ExampleMeaning = "Tính toán chi phí giao hàng."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 392,
            //    Word = "Contrast",
            //    Pronunciation = "ˈkɑntræst",
            //    Meaning = "Tương phản",
            //    Example = "In contrast to last year.",
            //    ExampleMeaning = "Ngược lại với năm ngoái."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 393,
            //    Word = "Monitor",
            //    Pronunciation = "ˈmɑnətər",
            //    Meaning = "Giám sát",
            //    Example = "Monitor the quality of products.",
            //    ExampleMeaning = "Giám sát chất lượng sản phẩm."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 394,
            //    Word = "Occasionally",
            //    Pronunciation = "əˈkeɪʒənəli",
            //    Meaning = "Thỉnh thoảng",
            //    Example = "I occasionally travel abroad.",
            //    ExampleMeaning = "Tôi thỉnh thoảng đi du lịch nước ngoài."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 395,
            //    Word = "Practical",
            //    Pronunciation = "ˈpræktɪkəl",
            //    Meaning = "Thực tiễn",
            //    Example = "Practical experience.",
            //    ExampleMeaning = "Kinh nghiệm thực tế."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 396,
            //    Word = "Serious",
            //    Pronunciation = "ˈsɪriəs",
            //    Meaning = "Nghiêm trọng",
            //    Example = "A serious problem.",
            //    ExampleMeaning = "Một vấn đề nghiêm trọng."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 397,
            //    Word = "Strength",
            //    Pronunciation = "strɛŋkθ",
            //    Meaning = "Sức mạnh, sở trường",
            //    Example = "The strength of materials.",
            //    ExampleMeaning = "Sức mạnh, độ cứng, độ bền của vật liệu."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 398,
            //    Word = "Equally",
            //    Pronunciation = "ˈikwəli",
            //    Meaning = "Bằng nhau",
            //    Example = "Equally important.",
            //    ExampleMeaning = "Quan trọng như nhau."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 399,
            //    Word = "Import",
            //    Pronunciation = "ˈɪmpɔrt",
            //    Meaning = "Nhập khẩu",
            //    Example = "Imports from China.",
            //    ExampleMeaning = "Nhập khẩu từ Trung Quốc."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 400,
            //    Word = "Informal",
            //    Pronunciation = "ɪnˈfɔrməl",
            //    Meaning = "Không chính thức",
            //    Example = "An informal survey.",
            //    ExampleMeaning = "Một cuộc khảo sát không chính thức."
            //});

            //#endregion

            //#region 401-500
            //#endregion

            //#region 501-600
            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 501,
            //    Word = "Fund-raising",
            //    Pronunciation = "fʌnd-ˈreɪzɪŋ",
            //    Meaning = "Gây quỹ",
            //    Example = "the fund-raising dinner",
            //    ExampleMeaning = "bữa tối gây quỹ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 502,
            //    Word = "Accomplish",
            //    Pronunciation = "əˈkɑmplɪʃt",
            //    Meaning = "Hoàn thành, thành tựu",
            //    Example = "an accomplished designer",
            //    ExampleMeaning = "một nhà thiết kế tài ba"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 503,
            //    Word = "Acquire",
            //    Pronunciation = "əˈkwaɪər",
            //    Meaning = "Có được, thu được",
            //    Example = "acquire a company",
            //    ExampleMeaning = "mua lại một công ty"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 504,
            //    Word = "Accordingly",
            //    Pronunciation = "əˈkɔrdɪŋli",
            //    Meaning = "Theo đó, tương ứng",
            //    Example = "this weather is cold, so dress accordingly",
            //    ExampleMeaning = "thời tiết này lạnh, nên ăn mặc phù hợp"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 505,
            //    Word = "Critic",
            //    Pronunciation = "ˈkrɪtɪk",
            //    Meaning = "Nhà Phê bình",
            //    Example = "positive reviews from critics",
            //    ExampleMeaning = "đánh giá tích cực từ các nhà phê bình"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 506,
            //    Word = "Highlight",
            //    Pronunciation = "ˈhaɪˌlaɪt",
            //    Meaning = "Điểm nổi bật, làm nổi bật",
            //    Example = "highlight differences",
            //    ExampleMeaning = "làm nổi bật sự khác biệt"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 507,
            //    Word = "Profile",
            //    Pronunciation = "ˈproʊˌfaɪl",
            //    Meaning = "Hồ sơ, giới thiệu",
            //    Example = "profile a businessperson",
            //    ExampleMeaning = "giới thiệu một doanh nhân"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 508,
            //    Word = "Motivate",
            //    Pronunciation = "ˈmoʊtəˌveɪt",
            //    Meaning = "Động viên, truyền cảm hứng",
            //    Example = "motivate employees",
            //    ExampleMeaning = "động viên nhân viên"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 509,
            //    Word = "Subscription",
            //    Pronunciation = "səbˈskrɪpʃən",
            //    Meaning = "Sự đăng ký",
            //    Example = "a magazine subscription",
            //    ExampleMeaning = "Sự đăng ký mua tạp chí"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 510,
            //    Word = "Encounter",
            //    Pronunciation = "ɪnˈkaʊntər",
            //    Meaning = "Gặp (vấn đề)",
            //    Example = "encounter a serious problem",
            //    ExampleMeaning = "gặp một vấn đề nghiêm trọng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 511,
            //    Word = "Luxury",
            //    Pronunciation = "ˈlʌgʒəri",
            //    Meaning = "Sang trọng",
            //    Example = "a luxury sedan",
            //    ExampleMeaning = "một chiếc xe sang"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 512,
            //    Word = "Prohibit",
            //    Pronunciation = "proʊˈhɪbət",
            //    Meaning = "Cấm",
            //    Example = "street parking is prohibited in this area",
            //    ExampleMeaning = "đậu xe trên đường phố bị cấm trong khu vực này"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 513,
            //    Word = "Resolve",
            //    Pronunciation = "riˈzɑlv",
            //    Meaning = "Giải quyết",
            //    Example = "the problem is resolved",
            //    ExampleMeaning = "vấn đề được giải quyết"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 514,
            //    Word = "Restore",
            //    Pronunciation = "rɪˈstɔr",
            //    Meaning = "Khôi phục",
            //    Example = "telephone service was restored this morning",
            //    ExampleMeaning = "dịch vụ điện thoại đã được khôi phục sáng nay"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 515,
            //    Word = "Surrounding",
            //    Pronunciation = "səˈraʊndɪŋ",
            //    Meaning = "Xung quanh",
            //    Example = "surrounding areas",
            //    ExampleMeaning = "khu vực xung quanh"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 516,
            //    Word = "Alert",
            //    Pronunciation = "əˈlɜrt",
            //    Meaning = "Thông báo",
            //    Example = "alert Tex to the problem",
            //    ExampleMeaning = "cảnh báo Tex về vấn đề"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 517,
            //    Word = "Anticipated",
            //    Pronunciation = "ænˈtɪsəˌpeɪtɪd",
            //    Meaning = "Dự kiến",
            //    Example = "the highly anticipated new book",
            //    ExampleMeaning = "cuốn sách mới rất được mong đợi"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 518,
            //    Word = "Consistently",
            //    Pronunciation = "kənˈsɪstəntli",
            //    Meaning = "Liên tục",
            //    Example = "consistently rank among the top 10 universities",
            //    ExampleMeaning = "liên tục được xếp hạng trong số 10 trường đại học hàng đầu"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 519,
            //    Word = "Dairy",
            //    Pronunciation = "ˈdɛri",
            //    Meaning = "Sữa, làm từ sữa",
            //    Example = "fat-free dairy products",
            //    ExampleMeaning = "sản phẩm không béo làm từ sữa"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 520,
            //    Word = "Phase",
            //    Pronunciation = "feɪz",
            //    Meaning = "Giai đoạn",
            //    Example = "the first phase",
            //    ExampleMeaning = "giai đoạn đầu tiên"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 521,
            //    Word = "Manuscript",
            //    Pronunciation = "ˈmænjəˌskrɪpt",
            //    Meaning = "Bản thảo",
            //    Example = "edit a manuscript",
            //    ExampleMeaning = "chỉnh sửa bản thảo"
            //});


            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 522,
            //    Word = "Overtime",
            //    Pronunciation = "ˈoʊvərˌtaɪm",
            //    Meaning = "Tăng ca",
            //    Example = "Work a lot of overtime",
            //    ExampleMeaning = "làm thêm giờ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 523,
            //    Word = "Premises",
            //    Pronunciation = "ˈprɛməsəz",
            //    Meaning = "Cơ sở, địa điểm",
            //    Example = "On the premises",
            //    ExampleMeaning = "trong khuôn viên"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 524,
            //    Word = "Utility",
            //    Pronunciation = "juˈtɪləti",
            //    Meaning = "Tiện ích, tiền điện nước",
            //    Example = "The rent includes all the utilities",
            //    ExampleMeaning = "tiền thuê bao gồm tất cả các tiện ích"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 525,
            //    Word = "Laundry",
            //    Pronunciation = "ˈlɔndri",
            //    Meaning = "Giặt ủi",
            //    Example = "A laundry room",
            //    ExampleMeaning = "phòng giặt ủi"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 526,
            //    Word = "Enthusiastic",
            //    Pronunciation = "ɪnˌθuziˈæstɪk",
            //    Meaning = "Nhiệt tình",
            //    Example = "I am enthusiastic about the project",
            //    ExampleMeaning = "Tôi cảm thấy hào hứng với dự án"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 527,
            //    Word = "Outline",
            //    Pronunciation = "ˈaʊtˌlaɪn",
            //    Meaning = "Đề cương, phác thảo",
            //    Example = "Outline a policy",
            //    ExampleMeaning = "phác thảo một chính sách"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 528,
            //    Word = "Packet",
            //    Pronunciation = "ˈpækɪt",
            //    Meaning = "Gói",
            //    Example = "A packet of materials",
            //    ExampleMeaning = "một gói vật liệu"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 529,
            //    Word = "Retain",
            //    Pronunciation = "rɪˈteɪn",
            //    Meaning = "Giữ lại",
            //    Example = "Retain a receipt",
            //    ExampleMeaning = "giữ lại biên lai"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 530,
            //    Word = "Belongings",
            //    Pronunciation = "bɪˈlɔŋɪŋz",
            //    Meaning = "Đồ đạc",
            //    Example = "Make sure you have all your belongings",
            //    ExampleMeaning = "Luôn lưu ý là bạn phải có tất cả đồ đạc của bạn"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 531,
            //    Word = "Conservation",
            //    Pronunciation = "ˌkɑnsərˈveɪʃən",
            //    Meaning = "Bảo tồn",
            //    Example = "Energy conservation",
            //    ExampleMeaning = "bảo tồn năng lượng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 532,
            //    Word = "Routine",
            //    Pronunciation = "ruˈtin",
            //    Meaning = "Theo định kì, hằng ngày",
            //    Example = "Routine maintenance work",
            //    ExampleMeaning = "công việc bảo trì định kỳ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 533,
            //    Word = "Urban",
            //    Pronunciation = "ˈɜrbən",
            //    Meaning = "Thành thị",
            //    Example = "Live in urban areas",
            //    ExampleMeaning = "sống ở thành thị"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 534,
            //    Word = "Workforce",
            //    Pronunciation = "ˈwɜrkˌfɔrs",
            //    Meaning = "Lực lượng lao động",
            //    Example = "50 percent of the workforce",
            //    ExampleMeaning = "50 phần trăm lực lượng lao động"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 535,
            //    Word = "Biography",
            //    Pronunciation = "baɪˈɑgrəfi",
            //    Meaning = "Tiểu sử",
            //    Example = "A brief biography of the author",
            //    ExampleMeaning = "tiểu sử tóm tắt của tác giả"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 536,
            //    Word = "Ownership",
            //    Pronunciation = "ˈoʊnərˌʃɪp",
            //    Meaning = "Quyền sở hữu",
            //    Example = "The company has recently changed ownership",
            //    ExampleMeaning = "công ty gần đây đã thay đổi quyền sở hữu"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 537,
            //    Word = "Pastry",
            //    Pronunciation = "ˈpeɪstri",
            //    Meaning = "Bánh ngọt",
            //    Example = "A pastry chef",
            //    ExampleMeaning = "một đầu bếp bánh ngọt"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 538,
            //    Word = "Tenant",
            //    Pronunciation = "ˈtɛnənt",
            //    Meaning = "Người thuê nhà",
            //    Example = "Both building managers and tenants",
            //    ExampleMeaning = "cả người quản lý tòa nhà và người thuê nhà"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 539,
            //    Word = "Workload",
            //    Pronunciation = "ˈwɜrkˌloʊd",
            //    Meaning = "Khối lượng công việc",
            //    Example = "Reduce the workforce",
            //    ExampleMeaning = "giảm lực lượng lao động"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 540,
            //    Word = "Sufficient",
            //    Pronunciation = "səˈfɪʃənt",
            //    Meaning = "Đủ",
            //    Example = "Sufficient time",
            //    ExampleMeaning = "đủ thời gian"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 541,
            //    Word = "Characteristic",
            //    Pronunciation = "ˌkɛrəktəˈrɪstɪk",
            //    Meaning = "Đặc điểm",
            //    Example = "Main characteristics of the product",
            //    ExampleMeaning = "đặc điểm chính của sản phẩm"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 542,
            //    Word = "Combine",
            //    Pronunciation = "ˈkɑmbaɪn",
            //    Meaning = "Phối hợp",
            //    Example = "A combined effort",
            //    ExampleMeaning = "một nỗ lực kết hợp"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 543,
            //    Word = "Conclude",
            //    Pronunciation = "kənˈklud",
            //    Meaning = "Kết luận, kết thúc",
            //    Example = "The event will conclude with a concert",
            //    ExampleMeaning = "sự kiện sẽ kết thúc bằng một buổi hòa nhạc"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 544,
            //    Word = "Associate",
            //    Pronunciation = "əˈsoʊsiˌeɪt",
            //    Meaning = "Cộng sự, liên quan",
            //    Example = "Cost associated with buying a house",
            //    ExampleMeaning = "chi phí liên quan đến việc mua một ngôi nhà"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 545,
            //    Word = "Conflict",
            //    Pronunciation = "ˈkɑnflɪkt",
            //    Meaning = "Cuộc xung đột",
            //    Example = "Because of a scheduling conflict",
            //    ExampleMeaning = "vì mâu thuẫn trong lịch trình"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 546,
            //    Word = "Investment",
            //    Pronunciation = "ɪnˈvɛstmənt",
            //    Meaning = "Sự đầu tư",
            //    Example = "Real estate investment",
            //    ExampleMeaning = "Sự đầu tư bất động sản"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 547,
            //    Word = "Physician",
            //    Pronunciation = "fəˈzɪʃən",
            //    Meaning = "Bác sĩ",
            //    Example = "See a physician",
            //    ExampleMeaning = "Gặp bác sĩ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 548,
            //    Word = "Token",
            //    Pronunciation = "ˈtoʊkən",
            //    Meaning = "Tượng trưng, thẻ chơi điện tử",
            //    Example = "As a token of our appreciation",
            //    ExampleMeaning = "như 1 lời cảm ơn, biết ơn từ chúng tôi"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 549,
            //    Word = "Partial",
            //    Pronunciation = "ˈpɑrʃəl",
            //    Meaning = "Một phần",
            //    Example = "A partial refund",
            //    ExampleMeaning = "hoàn lại một phần"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 550,
            //    Word = "Resume",
            //    Pronunciation = "rɪˈzum",
            //    Meaning = "Tiếp tục",
            //    Example = "Resume operation",
            //    ExampleMeaning = "tiếp tục hoạt động"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 551,
            //    Word = "Dealership",
            //    Pronunciation = "ˈdilərˌʃɪp",
            //    Meaning = "Đại lý",
            //    Example = "Car dealerships",
            //    ExampleMeaning = "đại lý xe hơi"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 552,
            //    Word = "Garment",
            //    Pronunciation = "ˈgɑrmənt",
            //    Meaning = "Quần áo",
            //    Example = "The garment is made of cotton",
            //    ExampleMeaning = "quần áo được làm từ cotton"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 553,
            //    Word = "Implement",
            //    Pronunciation = "ˈɪmpləˌmɛnt",
            //    Meaning = "Triển khai, thực hiện",
            //    Example = "Security measures were implemented",
            //    ExampleMeaning = "biện pháp an ninh đã được thực hiện"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 554,
            //    Word = "Paycheck",
            //    Pronunciation = "ˈpeɪˌʧɛk",
            //    Meaning = "Tiền lương",
            //    Example = "Receive a paycheck",
            //    ExampleMeaning = "nhận tiền lương"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 555,
            //    Word = "Recruit",
            //    Pronunciation = "rɪˈkrut",
            //    Meaning = "Tuyển dụng",
            //    Example = "Recruit new staff",
            //    ExampleMeaning = "tuyển nhân viên mới"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 556,
            //    Word = "Substitute",
            //    Pronunciation = "ˈsʌbstəˌtut",
            //    Meaning = "Thay thế",
            //    Example = "Substitute new for old",
            //    ExampleMeaning = "thay thế cái cũ bằng cái mới"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 557,
            //    Word = "Typically",
            //    Pronunciation = "ˈtɪpɪkəli",
            //    Meaning = "Điển hình là",
            //    Example = "Our tour typically takes an hour",
            //    ExampleMeaning = "tour du lịch của chúng tôi thường mất một giờ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 558,
            //    Word = "Authorize",
            //    Pronunciation = "ˈɔθəˌraɪz",
            //    Meaning = "Ủy quyền",
            //    Example = "An authorized dealer",
            //    ExampleMeaning = "một đại lý ủy quyền"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 559,
            //    Word = "Comparable",
            //    Pronunciation = "kəmˈpɛrəbəl",
            //    Meaning = "So sánh",
            //    Example = "More expensive than comparable products",
            //    ExampleMeaning = "đắt hơn các sản phẩm tương đương"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 560,
            //    Word = "Faculty",
            //    Pronunciation = "ˈfækəlti",
            //    Meaning = "Khoa",
            //    Example = "A faculty member at Tex College",
            //    ExampleMeaning = "một giảng viên tại Tex College"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 561,
            //    Word = "Initiative",
            //    Pronunciation = "ɪˈnɪʃətɪv",
            //    Meaning = "Sáng kiến",
            //    Example = "A growth initiative",
            //    ExampleMeaning = "một sáng kiến tăng trưởng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 562,
            //    Word = "Postage",
            //    Pronunciation = "ˈpoʊstɪʤ",
            //    Meaning = "Bưu chính",
            //    Example = "Postage is calculated by weight",
            //    ExampleMeaning = "cước bưu chính được tính theo trọng lượng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 563,
            //    Word = "Afterwards",
            //    Pronunciation = "ˈæftərwərdz",
            //    Meaning = "Sau đó",
            //    Example = "The author will sign books afterwards",
            //    ExampleMeaning = "tác giả sẽ ký sách sau đó"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 564,
            //    Word = "Aim",
            //    Pronunciation = "eɪm",
            //    Meaning = "Mục đích",
            //    Example = "Aim to cut energy use",
            //    ExampleMeaning = "nhằm mục đích cắt giảm sử dụng năng lượng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 565,
            //    Word = "Generally",
            //    Pronunciation = "ˈʤɛnərəli",
            //    Meaning = "Nói chung là",
            //    Example = "The film received generally positive reviews",
            //    ExampleMeaning = "bộ phim nhận được đánh giá tích cực"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 566,
            //    Word = "Occupied",
            //    Pronunciation = "ˈɑkjəˌpaɪd",
            //    Meaning = "Chiếm",
            //    Example = "The room is occupied",
            //    ExampleMeaning = "phòng bị chiếm, có người sử dụng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 567,
            //    Word = "Solid",
            //    Pronunciation = "ˈsɑləd",
            //    Meaning = "Chất rắn, vững chắc",
            //    Example = "A solid reputation",
            //    ExampleMeaning = "danh tiếng vững chắc"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 568,
            //    Word = "Attempt",
            //    Pronunciation = "əˈtɛmpt",
            //    Meaning = "Cố gắng",
            //    Example = "Tex's attempt to become a singer",
            //    ExampleMeaning = "Nỗ lực của Tex để trở thành ca sĩ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 569,
            //    Word = "Authority",
            //    Pronunciation = "əˈθɔrəti",
            //    Meaning = "Thẩm quyền",
            //    Example = "A person in authority",
            //    ExampleMeaning = "một người có thẩm quyền"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 570,
            //    Word = "Domestic",
            //    Pronunciation = "dəˈmɛstɪk",
            //    Meaning = "Trong nước",
            //    Example = "The domestic market",
            //    ExampleMeaning = "thị trường nội địa"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 571,
            //    Word = "Permission",
            //    Pronunciation = "pərˈmɪʃən",
            //    Meaning = "Giấy phép",
            //    Example = "Without permission",
            //    ExampleMeaning = "mà không có sự cho phép"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 572,
            //    Word = "Presence",
            //    Pronunciation = "ˈprɛzəns",
            //    Meaning = "Sự hiện diện",
            //    Example = "A strong presence in the area",
            //    ExampleMeaning = "sự hiện diện mạnh mẽ trong khu vực"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 573,
            //    Word = "Rapidly",
            //    Pronunciation = "ˈræpədli",
            //    Meaning = "Nhanh chóng",
            //    Example = "A rapidly growing company",
            //    ExampleMeaning = "một công ty phát triển nhanh chóng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 574,
            //    Word = "Relief",
            //    Pronunciation = "rɪˈlif",
            //    Meaning = "Cứu trợ",
            //    Example = "Provide relief to consumers",
            //    ExampleMeaning = "giảm gánh nặng cho người tiêu dùng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 575,
            //    Word = "Reward",
            //    Pronunciation = "rɪˈwɔrd",
            //    Meaning = "Phần thưởng, thưởng",
            //    Example = "Reward employees for their hard work",
            //    ExampleMeaning = "khen thưởng nhân viên vì đã làm việc chăm chỉ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 576,
            //    Word = "Translate",
            //    Pronunciation = "trænˈsleɪt",
            //    Meaning = "Dịch",
            //    Example = "Translate English into Japanese",
            //    ExampleMeaning = "dịch tiếng anh sang tiếng nhật"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 577,
            //    Word = "Circumstance",
            //    Pronunciation = "ˈsɜrkəmˌstæns",
            //    Meaning = "Hoàn cảnh",
            //    Example = "Under any circumstances",
            //    ExampleMeaning = "trong mọi trường hợp"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 578,
            //    Word = "Contrary",
            //    Pronunciation = "ˈkɑntrɛri",
            //    Meaning = "Trái ngược",
            //    Example = "Contrary to expectations",
            //    ExampleMeaning = "không như kỳ vọng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 579,
            //    Word = "Eventually",
            //    Pronunciation = "ɪˈvɛnʃəli",
            //    Meaning = "Cuối cùng",
            //    Example = "Mr. Kato was eventually promoted to CEO",
            //    ExampleMeaning = "Ông Kato cuối cùng đã được thăng chức CEO"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 580,
            //    Word = "Expose",
            //    Pronunciation = "ɪkˈspoʊz",
            //    Meaning = "Lộ ra",
            //    Example = "Be directly exposed to the sun",
            //    ExampleMeaning = "bị tiếp xúc trực tiếp với ánh nắng mặt trời"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 581,
            //    Word = "Panel",
            //    Pronunciation = "ˈpænəl",
            //    Meaning = "Bảng điều khiển, hội đồng",
            //    Example = "A panel of experts",
            //    ExampleMeaning = "một nhóm chuyên gia"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 582,
            //    Word = "Portion",
            //    Pronunciation = "ˈpɔrʃən",
            //    Meaning = "Phần",
            //    Example = "The bottom portion of the ticket",
            //    ExampleMeaning = "phần dưới cùng của vé"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 583,
            //    Word = "Primary",
            //    Pronunciation = "ˈpraɪˌmɛri",
            //    Meaning = "Sơ cấp, chủ đạo",
            //    Example = "Primary duties",
            //    ExampleMeaning = "Nhiệm vụ chính"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 584,
            //    Word = "Remark",
            //    Pronunciation = "rɪˈmɑrk",
            //    Meaning = "Ghi chú, bài nói",
            //    Example = "Opening remark",
            //    ExampleMeaning = "Diễn văn khai mạc"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 585,
            //    Word = "Timely",
            //    Pronunciation = "ˈtaɪmli",
            //    Meaning = "Kịp thời",
            //    Example = "In a timely manner",
            //    ExampleMeaning = "kịp thời"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 586,
            //    Word = "Commonly",
            //    Pronunciation = "ˈkɑmənli",
            //    Meaning = "Thông thường",
            //    Example = "The most commonly used methods",
            //    ExampleMeaning = "phương pháp được sử dụng phổ biến nhất"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 587,
            //    Word = "Consult",
            //    Pronunciation = "kənˈsʌlt",
            //    Meaning = "Tham khảo ý kiến",
            //    Example = "Consult a doctor",
            //    ExampleMeaning = "tham khảo một bác sĩ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 588,
            //    Word = "Convert",
            //    Pronunciation = "kənˈvɜrt",
            //    Meaning = "Đổi",
            //    Example = "Convert a warehouse into an office",
            //    ExampleMeaning = "chuyển công năng một nhà kho thành một văn phòng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 589,
            //    Word = "Obligation",
            //    Pronunciation = "ˌɑbləˈgeɪʃən",
            //    Meaning = "Nghĩa vụ",
            //    Example = "You have no obligation to do so",
            //    ExampleMeaning = "bạn không có nghĩa vụ phải làm như vậy"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 590,
            //    Word = "Resign",
            //    Pronunciation = "rɪˈzaɪn",
            //    Meaning = "Từ chức",
            //    Example = "Resign without notice",
            //    ExampleMeaning = "từ chức mà không báo trước"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 591,
            //    Word = "Securely",
            //    Pronunciation = "sɪˈkjʊrli",
            //    Meaning = "An toàn",
            //    Example = "The door is securely locked",
            //    ExampleMeaning = "cửa được khóa an toàn"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 592,
            //    Word = "Strive",
            //    Pronunciation = "straɪv",
            //    Meaning = "Phấn đấu",
            //    Example = "Strive to cut cost",
            //    ExampleMeaning = "phấn đấu để cắt giảm chi phí"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 593,
            //    Word = "Timeline",
            //    Pronunciation = "ˈtaɪmlaɪn",
            //    Meaning = "Mốc thời gian",
            //    Example = "A timeline of events",
            //    ExampleMeaning = "dòng thời gian của sự kiện"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 594,
            //    Word = "Urge",
            //    Pronunciation = "ɜrʤ",
            //    Meaning = "Thúc giục",
            //    Example = "Urge Tex to change his mind",
            //    ExampleMeaning = "kêu gọi Tex thay đổi suy nghĩ của mình"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 595,
            //    Word = "Acknowledge",
            //    Pronunciation = "ækˈnɑlɪʤ",
            //    Meaning = "Công nhận",
            //    Example = "Acknowledge the receipt of the order",
            //    ExampleMeaning = "xác nhận đã nhận được đơn đặt hàng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 596,
            //    Word = "Diverse",
            //    Pronunciation = "daɪˈvɜrs",
            //    Meaning = "Phong phú",
            //    Example = "A diverse group of experts",
            //    ExampleMeaning = "một nhóm các chuyên gia đa dạng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 597,
            //    Word = "Transaction",
            //    Pronunciation = "trænˈzækʃən",
            //    Meaning = "Giao dịch",
            //    Example = "A bank transaction",
            //    ExampleMeaning = "giao dịch ngân hàng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 598,
            //    Word = "Lack",
            //    Pronunciation = "læk",
            //    Meaning = "Thiếu sót",
            //    Example = "A lack of information",
            //    ExampleMeaning = "thiếu thông tin"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 599,
            //    Word = "Essential",
            //    Pronunciation = "ɪˈsɛnʃəl",
            //    Meaning = "Cần thiết",
            //    Example = "Customer satisfaction is essential to us",
            //    ExampleMeaning = "sự hài lòng của khách hàng là điều cần thiết cho chúng tôi"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 600,
            //    Word = "Majority",
            //    Pronunciation = "məˈʤɔrəti",
            //    Meaning = "Đa số",
            //    Example = "The majority of employees",
            //    ExampleMeaning = "phần lớn nhân viên"
            //});

            //#endregion

            //#region 601-700
            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 601,
            //    Word = "Observe",
            //    Pronunciation = "əbˈzɜrv",
            //    Meaning = "Quan sát",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 602,
            //    Word = "Possess",
            //    Pronunciation = "pəˈzɛs",
            //    Meaning = "Sở hữu",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 603,
            //    Word = "Sharply",
            //    Pronunciation = "ˈʃɑrpli",
            //    Meaning = "Chính xác, đúng giờ",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 604,
            //    Word = "Adjustment",
            //    Pronunciation = "əˈʤʌstmənt",
            //    Meaning = "Sự điều chỉnh",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 605,
            //    Word = "Aisle",
            //    Pronunciation = "ˈaɪəl",
            //    Meaning = "Lối đi giữa 2 hàng kệ",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 606,
            //    Word = "Capture",
            //    Pronunciation = "ˈkæpʧər",
            //    Meaning = "Chụp, thu được",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 607,
            //    Word = "Consist",
            //    Pronunciation = "kənˈsɪst",
            //    Meaning = "Bao gồm",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 608,
            //    Word = "Desirable",
            //    Pronunciation = "dɪˈzaɪərəbəl",
            //    Meaning = "Đáng mong muốn",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 609,
            //    Word = "Heavily",
            //    Pronunciation = "ˈhɛvəli",
            //    Meaning = "Nặng nề, nhiều",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 610,
            //    Word = "Investigate",
            //    Pronunciation = "ɪnˈvɛstəˌgeɪt",
            //    Meaning = "Điều tra",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 611,
            //    Word = "Measurement",
            //    Pronunciation = "ˈmɛʒərmənt",
            //    Meaning = "Sự đo lường, số đo",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 612,
            //    Word = "Urgent",
            //    Pronunciation = "ˈɜrʤənt",
            //    Meaning = "Khẩn cấp",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 613,
            //    Word = "Checkout",
            //    Pronunciation = "ˈʧɛˌkaʊt",
            //    Meaning = "Kiểm tra, chỗ thanh toán",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 614,
            //    Word = "Dispose",
            //    Pronunciation = "dɪˈspoʊz",
            //    Meaning = "Vứt bỏ",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 615,
            //    Word = "Modify",
            //    Pronunciation = "ˈmɑdəˌfaɪ",
            //    Meaning = "Sửa đổi",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 616,
            //    Word = "Outlet",
            //    Pronunciation = "ˈaʊtˌlɛt",
            //    Meaning = "Cửa hàng, ổ ghim điện",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 617,
            //    Word = "Prescription",
            //    Pronunciation = "prəˈskrɪpʃən",
            //    Meaning = "Đơn thuốc",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 618,
            //    Word = "Situate",
            //    Pronunciation = "ˈsɪʧuˌeɪt",
            //    Meaning = "Nằm ở",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 619,
            //    Word = "Surprisingly",
            //    Pronunciation = "sərˈpraɪzɪŋli",
            //    Meaning = "Đáng ngạc nhiên",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 620,
            //    Word = "Transform",
            //    Pronunciation = "trænˈsfɔrm",
            //    Meaning = "Biến đổi",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 621,
            //    Word = "Undergo",
            //    Pronunciation = "ˌʌndərˈgoʊ",
            //    Meaning = "Trải qua",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 622,
            //    Word = "Blueprint",
            //    Pronunciation = "ˈbluˌprɪnt",
            //    Meaning = "Bản vẽ thiết kế",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 623,
            //    Word = "Boost",
            //    Pronunciation = "bust",
            //    Meaning = "Tăng cường, nâng cao",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 624,
            //    Word = "Considerably",
            //    Pronunciation = "kənˈsɪdərəbli",
            //    Meaning = "Nhiều, đáng chú",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 625,
            //    Word = "Eliminate",
            //    Pronunciation = "ɪˈlɪməˌneɪt",
            //    Meaning = "Loại bỏ",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 626,
            //    Word = "Exclusively",
            //    Pronunciation = "ɪkˈsklusɪvli",
            //    Meaning = "Duy nhất, dành riêng",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 627,
            //    Word = "Leak",
            //    Pronunciation = "lik",
            //    Meaning = "Rò rỉ",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 628,
            //    Word = "Preliminary",
            //    Pronunciation = "prɪˈlɪməˌnɛri",
            //    Meaning = "Sơ bộ, vòng loại",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 629,
            //    Word = "Sophisticated",
            //    Pronunciation = "səˈfɪstɪˌkeɪtəd",
            //    Meaning = "Tinh vi, tinh tế",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 630,
            //    Word = "Statistics",
            //    Pronunciation = "stəˈtɪstɪks",
            //    Meaning = "Số liệu thống kê",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 631,
            //    Word = "Vacant",
            //    Pronunciation = "ˈveɪkənt",
            //    Meaning = "Trống, vắng",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 632,
            //    Word = "Evidence",
            //    Pronunciation = "ˈɛvədəns",
            //    Meaning = "Chứng cớ",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 633,
            //    Word = "Excursion",
            //    Pronunciation = "ɪkˈskɜrʒən",
            //    Meaning = "Chuyến tham quan",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 634,
            //    Word = "Influence",
            //    Pronunciation = "ˈɪnfluəns",
            //    Meaning = "Sự ảnh hưởng",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 635,
            //    Word = "Ordinary",
            //    Pronunciation = "ˈɔrdəˌnɛri",
            //    Meaning = "Mang tính bình thường",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 636,
            //    Word = "Reject",
            //    Pronunciation = "rɪˈʤɛkt",
            //    Meaning = "Từ chối",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 637,
            //    Word = "Tailor",
            //    Pronunciation = "ˈteɪlər",
            //    Meaning = "Thợ may",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 638,
            //    Word = "Assume",
            //    Pronunciation = "əˈsum",
            //    Meaning = "Giả định, nhậm chức",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 639,
            //    Word = "Engagement",
            //    Pronunciation = "ɛnˈgeɪʤmənt",
            //    Meaning = "Hôn ước, sự tham gia"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 640,
            //    Word = "Fame",
            //    Pronunciation = "feɪm",
            //    Meaning = "Danh tiếng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 641,
            //    Word = "Modest",
            //    Pronunciation = "ˈmɑdəst",
            //    Meaning = "Khiêm tốn"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 642,
            //    Word = "Patent",
            //    Pronunciation = "ˈpætənt",
            //    Meaning = "Bằng sáng chế"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 643,
            //    Word = "Pursue",
            //    Pronunciation = "pərˈsu",
            //    Meaning = "Theo đuổi"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 644,
            //    Word = "Remote",
            //    Pronunciation = "rɪˈmoʊt",
            //    Meaning = "Từ xa, hẻo lánh"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 645,
            //    Word = "Reveal",
            //    Pronunciation = "rɪˈvil",
            //    Meaning = "Tiết lộ, hé lộ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 646,
            //    Word = "Allowance",
            //    Pronunciation = "əˈlaʊəns",
            //    Meaning = "Phụ cấp, tiền tiêu vặt"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 647,
            //    Word = "Crucial",
            //    Pronunciation = "ˈkruʃəl",
            //    Meaning = "Quan trọng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 648,
            //    Word = "Distinguish",
            //    Pronunciation = "dɪˈstɪŋgwɪʃ",
            //    Meaning = "Phân biệt"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 649,
            //    Word = "Disturb",
            //    Pronunciation = "dɪˈstɜrb",
            //    Meaning = "Làm phiền"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 650,
            //    Word = "Fluent",
            //    Pronunciation = "ˈfluənt",
            //    Meaning = "Thông thạo"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 651,
            //    Word = "Fulfill",
            //    Pronunciation = "fʊlˈfɪl",
            //    Meaning = "Hoàn thành, thỏa nguyện"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 652,
            //    Word = "Objective",
            //    Pronunciation = "əbˈʤɛktɪv",
            //    Meaning = "Mục tiêu, khách quan"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 653,
            //    Word = "Restrict",
            //    Pronunciation = "riˈstrɪkt",
            //    Meaning = "Hạn chế, cấm"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 654,
            //    Word = "Steadily",
            //    Pronunciation = "ˈstɛdəli",
            //    Meaning = "Ổn định"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 655,
            //    Word = "Adequate",
            //    Pronunciation = "ˈædəˌkweɪt",
            //    Meaning = "Đầy đủ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 656,
            //    Word = "Assessment",
            //    Pronunciation = "əˈsɛsmənt",
            //    Meaning = "Thẩm định, đánh giá, bài thi"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 657,
            //    Word = "Attribute",
            //    Pronunciation = "əˈtrɪˌbjut",
            //    Meaning = "Tính chất, có được là nhờ..."
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 658,
            //    Word = "Beforehand",
            //    Pronunciation = "bɪˈfɔrˌhænd",
            //    Meaning = "Làm ... trước"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 659,
            //    Word = "Challenging",
            //    Pronunciation = "ˈʧælənʤɪŋ",
            //    Meaning = "Đầy thách thức"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 660,
            //    Word = "Endeavor",
            //    Pronunciation = "ɪnˈdɛvər",
            //    Meaning = "Nỗ lực, năng lực"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 661,
            //    Word = "Inspiring",
            //    Pronunciation = "ɪnˈspaɪərɪŋ",
            //    Meaning = "Đầy cảm hứng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 662,
            //    Word = "Remarkable",
            //    Pronunciation = "rɪˈmɑrkəbəl",
            //    Meaning = "Đáng chú ý, nhiều"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 663,
            //    Word = "Measure",
            //    Pronunciation = "ˈmɛʒər",
            //    Meaning = "Đo, biện pháp"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 664,
            //    Word = "Struggle",
            //    Pronunciation = "ˈstrʌgəl",
            //    Meaning = "Sự đấu tranh, gian nan"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 665,
            //    Word = "Wage",
            //    Pronunciation = "weɪʤ",
            //    Meaning = "Tiền lương, thường tính theo giờ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 666,
            //    Word = "Adapt",
            //    Pronunciation = "əˈdæpt",
            //    Meaning = "Phỏng theo, dựa trên"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 667,
            //    Word = "Ambitious",
            //    Pronunciation = "æmˈbɪʃəs",
            //    Meaning = "Đầy tham vọng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 668,
            //    Word = "Capable",
            //    Pronunciation = "ˈkeɪpəbəl",
            //    Meaning = "Có khả năng, có năng lực"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 669,
            //    Word = "Consequence",
            //    Pronunciation = "ˈkɑnsəkwəns",
            //    Meaning = "Kết quả, hậu quả"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 670,
            //    Word = "Impose",
            //    Pronunciation = "ɪmˈpoʊz",
            //    Meaning = "Áp đặt"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 671,
            //    Word = "Latter",
            //    Pronunciation = "ˈlætər",
            //    Meaning = "Cái thứ 2, cái đằng sau"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 672,
            //    Word = "Output",
            //    Pronunciation = "ˈaʊtˌpʊt",
            //    Meaning = "Đầu ra, kết quả"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 673,
            //    Word = "Proudly",
            //    Pronunciation = "ˈpraʊdli",
            //    Meaning = "Tự hào"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 674,
            //    Word = "Stable",
            //    Pronunciation = "ˈsteɪbəl",
            //    Meaning = "Ổn định"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 675,
            //    Word = "Transition",
            //    Pronunciation = "trænˈzɪʃən",
            //    Meaning = "Chuyển đổi"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 676,
            //    Word = "Consent",
            //    Pronunciation = "kənˈsɛnt",
            //    Meaning = "Bằng lòng, sự cho phép"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 677,
            //    Word = "Dependable",
            //    Pronunciation = "dɪˈpɛndəbəl",
            //    Meaning = "Đáng tin cậy"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 678,
            //    Word = "Diligent",
            //    Pronunciation = "ˈdɪlɪʤənt",
            //    Meaning = "Siêng năng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 679,
            //    Word = "Illustrate",
            //    Pronunciation = "ˈɪləˌstreɪt",
            //    Meaning = "Minh họa"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 680,
            //    Word = "Independently",
            //    Pronunciation = "ˌɪndɪˈpɛndəntli",
            //    Meaning = "Độc lập",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 681,
            //    Word = "Mission",
            //    Pronunciation = "ˈmɪʃən",
            //    Meaning = "Sứ mệnh",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 682,
            //    Word = "Moderate",
            //    Pronunciation = "ˈmɑdərət",
            //    Meaning = "Vừa phải",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 683,
            //    Word = "Outlook",
            //    Pronunciation = "ˈaʊtˌlʊk",
            //    Meaning = "Triển vọng",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 684,
            //    Word = "Precisely",
            //    Pronunciation = "prɪˈsaɪsli",
            //    Meaning = "Đúng, chính xác",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 685,
            //    Word = "Concentrated",
            //    Pronunciation = "ˈkɔnsənˌtreɪtɪd",
            //    Meaning = "Tập trung, cô đặc",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 686,
            //    Word = "Ample",
            //    Pronunciation = "ˈæmpəl",
            //    Meaning = "Đủ",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 687,
            //    Word = "Asset",
            //    Pronunciation = "ˈæˌsɛt",
            //    Meaning = "Tài sản",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 688,
            //    Word = "Controversial",
            //    Pronunciation = "ˌkɑntrəˈvɜrʃəl",
            //    Meaning = "Gây tranh cãi",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 689,
            //    Word = "Disappointing",
            //    Pronunciation = "ˌdɪsəˈpɔɪntɪŋ",
            //    Meaning = "Gây thất vọng",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 690,
            //    Word = "Instrumental",
            //    Pronunciation = "ˌɪnstrəˈmɛntəl",
            //    Meaning = "Có vai trò quan trọng",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 691,
            //    Word = "Interruption",
            //    Pronunciation = "ˌɪntəˈrʌpʃən",
            //    Meaning = "Sự gián đoạn",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 692,
            //    Word = "Perspective",
            //    Pronunciation = "pərˈspɛktɪv",
            //    Meaning = "Quan điểm",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 693,
            //    Word = "Scope",
            //    Pronunciation = "skoʊp",
            //    Meaning = "Phạm vi, ống nhìn",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 694,
            //    Word = "Speculation",
            //    Pronunciation = "ˌspɛkjəˈleɪʃən",
            //    Meaning = "Sự phòng đoán",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 695,
            //    Word = "Supplement",
            //    Pronunciation = "ˈsʌpləmənt",
            //    Meaning = "Phần bổ sung",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 696,
            //    Word = "Understaff",
            //    Pronunciation = "ˈʌndərˌstæf",
            //    Meaning = "Thiếu nhân lực",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 697,
            //    Word = "Rarely",
            //    Pronunciation = "ˈrɛrli",
            //    Meaning = "Ít khi",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 698,
            //    Word = "Caution",
            //    Pronunciation = "ˈkɔʃən",
            //    Meaning = "Thận trọng, cảnh báo",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 699,
            //    Word = "Legislation",
            //    Pronunciation = "ˌlɛʤəˈsleɪʃən",
            //    Meaning = "Pháp luật",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 700,
            //    Word = "Logical",
            //    Pronunciation = "ˈlɑʤɪkəl",
            //    Meaning = "Hợp lý",
            //});
            //#endregion

            //#region 701-800

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 701,
            //    Word = "Lumber",
            //    Pronunciation = "ˈlʌmbər",
            //    Meaning = "Ngành gỗ",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 702,
            //    Word = "Reverse",
            //    Pronunciation = "rɪˈvɜrs",
            //    Meaning = "Đảo ngược, ngược lại",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 703,
            //    Word = "Voluntary",
            //    Pronunciation = "ˈvɑləntɛri",
            //    Meaning = "Tình nguyện",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 704,
            //    Word = "Contractor",
            //    Pronunciation = "ˈkɑnˌtræktər",
            //    Meaning = "Nhà thầu",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 705,
            //    Word = "On-site",
            //    Pronunciation = "ɔn-saɪt",
            //    Meaning = "Tại chỗ",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 706,
            //    Word = "Comprehensive",
            //    Pronunciation = "ˌkɑmpriˈhɛnsɪv",
            //    Meaning = "Toàn diện",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 707,
            //    Word = "Confidential",
            //    Pronunciation = "ˌkɑnfəˈdɛnʃəl",
            //    Meaning = "Bí mật",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 708,
            //    Word = "Expertise",
            //    Pronunciation = "ˌɛkspərˈtiz",
            //    Meaning = "Chuyên môn",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 709,
            //    Word = "Premier",
            //    Pronunciation = "priˈmɪr",
            //    Meaning = "Buổi công chiếu, hàng đầu",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 710,
            //    Word = "Souvenir",
            //    Pronunciation = "ˌsuvəˈnɪr",
            //    Meaning = "Quà lưu niệm",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 711,
            //    Word = "Rafting",
            //    Pronunciation = "ˈræftɪŋ",
            //    Meaning = "Đi bằng bè",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 712,
            //    Word = "Compartment",
            //    Pronunciation = "kəmˈpɑrtmənt",
            //    Meaning = "Ngăn chứa",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 713,
            //    Word = "Fabric",
            //    Pronunciation = "ˈfæbrɪk",
            //    Meaning = "Chất liệu, vải",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 714,
            //    Word = "Spacious",
            //    Pronunciation = "ˈspeɪʃəs",
            //    Meaning = "Rộng rãi",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 715,
            //    Word = "Upgrade",
            //    Pronunciation = "ˈʌpgreɪd",
            //    Meaning = "Nâng cấp",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 716,
            //    Word = "Showcase",
            //    Pronunciation = "ˈʃoʊˌkeɪs",
            //    Meaning = "Trưng bày",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 717,
            //    Word = "Commuter",
            //    Pronunciation = "kəmˈjutər",
            //    Meaning = "Người phải dành nhiều thời gian để đến chỗ làm",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 718,
            //    Word = "Enhance",
            //    Pronunciation = "ɛnˈhæns",
            //    Meaning = "Cải thiện, nâng cấp",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 719,
            //    Word = "Freight",
            //    Pronunciation = "freɪt",
            //    Meaning = "Hàng hóa trong lúc vận chuyển",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 720,
            //    Word = "Nominate",
            //    Pronunciation = "ˈnɑməˌneɪt",
            //    Meaning = "Đề cử",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 721,
            //    Word = "Discontinue",
            //    Pronunciation = "dɪskənˈtɪnju",
            //    Meaning = "Ngưng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 722,
            //    Word = "Mentoring",
            //    Pronunciation = "ˈmɛntərɪŋ",
            //    Meaning = "Kèm cặp"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 723,
            //    Word = "Personalize",
            //    Pronunciation = "ˈpɜrsənəˌlaɪz",
            //    Meaning = "Cá nhân hóa"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 724,
            //    Word = "Pharmacy",
            //    Pronunciation = "ˈfɑrməsi",
            //    Meaning = "Tiệm thuốc"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 725,
            //    Word = "Excerpt",
            //    Pronunciation = "ˈɛksɜrpt",
            //    Meaning = "Trích đoạn"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 726,
            //    Word = "Publicize",
            //    Pronunciation = "ˈpʌblɪˌsaɪz",
            //    Meaning = "Công khai"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 727,
            //    Word = "Tuition",
            //    Pronunciation = "tjuˈɪʃən",
            //    Meaning = "Học phí"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 728,
            //    Word = "Compliance",
            //    Pronunciation = "kəmˈplaɪəns",
            //    Meaning = "Sự tuân thủ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 729,
            //    Word = "Clarify",
            //    Pronunciation = "ˈklɛrəˌfaɪ",
            //    Meaning = "Làm rõ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 730,
            //    Word = "Municipal",
            //    Pronunciation = "mjuˈnɪsəpəl",
            //    Meaning = "Cấp thành phố"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 731,
            //    Word = "Respectively",
            //    Pronunciation = "rɪˈspɛktɪvli",
            //    Meaning = "Tương ứng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 732,
            //    Word = "Durable",
            //    Pronunciation = "ˈdʊrəbəl",
            //    Meaning = "Bền, xài lâu"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 733,
            //    Word = "Landmark",
            //    Pronunciation = "ˈlændˌmɑrk",
            //    Meaning = "Cột mốc"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 734,
            //    Word = "Portfolio",
            //    Pronunciation = "pɔrtˈfoʊliˌoʊ",
            //    Meaning = "Danh mục đầu tư"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 735,
            //    Word = "Recipient",
            //    Pronunciation = "rəˈsɪpiənt",
            //    Meaning = "Người nhận"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 736,
            //    Word = "Prototype",
            //    Pronunciation = "ˈproʊtəˌtaɪp",
            //    Meaning = "Mẫu thử"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 737,
            //    Word = "Transit",
            //    Pronunciation = "ˈtrænzɪt",
            //    Meaning = "Quá cảnh, chuyển tiếp"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 738,
            //    Word = "Verify",
            //    Pronunciation = "ˈvɛrəˌfaɪ",
            //    Meaning = "Kiểm chứng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 739,
            //    Word = "Managerial",
            //    Pronunciation = "ˌmænɪˈʤɪriəl",
            //    Meaning = "Mang tính quản lý"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 740,
            //    Word = "Culinary",
            //    Pronunciation = "ˈkjulɪˌnɛri",
            //    Meaning = "Giáo dục về ẩm thực"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 741,
            //    Word = "Attire",
            //    Pronunciation = "əˈtaɪər",
            //    Meaning = "Trang phục"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 742,
            //    Word = "Reimburse",
            //    Pronunciation = "ˌriɪmˈbɜrs",
            //    Meaning = "Hoàn tiền"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 743,
            //    Word = "Courteous",
            //    Pronunciation = "ˈkɜrtiəs",
            //    Meaning = "Lịch sự"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 744,
            //    Word = "Furnished",
            //    Pronunciation = "ˈfɜrnɪʃt",
            //    Meaning = "Đầy đủ nội thất"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 745,
            //    Word = "Knowledgeable",
            //    Pronunciation = "ˈnɑləʤəbəl",
            //    Meaning = "Có kiến thức"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 746,
            //    Word = "Craftspeople",
            //    Pronunciation = "ˈkræftˌspipəl",
            //    Meaning = "Nghệ nhân"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 747,
            //    Word = "Delete",
            //    Pronunciation = "dɪˈlit",
            //    Meaning = "Xóa bỏ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 748,
            //    Word = "Emerging",
            //    Pronunciation = "ˈimərʤɪŋ",
            //    Meaning = "Xuất hiện, hiện diện"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 749,
            //    Word = "Enroll",
            //    Pronunciation = "ɪnˈroʊl",
            //    Meaning = "Ghi danh, đăng kí"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 750,
            //    Word = "Proficiency",
            //    Pronunciation = "prəˈfɪʃənsi",
            //    Meaning = "Có năng lực, sự thành thạo"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 751,
            //    Word = "Scenic",
            //    Pronunciation = "ˈsinɪk",
            //    Meaning = "Phong cảnh"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 752,
            //    Word = "State-of-the-art",
            //    Pronunciation = "steɪt-ʌv-ði-ɑrt",
            //    Meaning = "Hiện đại nhất"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 753,
            //    Word = "Cuisine",
            //    Pronunciation = "kwɪˈzin",
            //    Meaning = "Nền ẩm thực"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 754,
            //    Word = "Acclaim",
            //    Pronunciation = "əˈkleɪm",
            //    Meaning = "Tung hô"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 755,
            //    Word = "Certify",
            //    Pronunciation = "ˈsɜrtəˌfaɪ",
            //    Meaning = "Chứng nhận"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 756,
            //    Word = "Medication",
            //    Pronunciation = "ˌmɛdəˈkeɪʃən",
            //    Meaning = "Thuốc"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 757,
            //    Word = "Overview",
            //    Pronunciation = "ˈoʊvərˌvju",
            //    Meaning = "Tổng quan"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 758,
            //    Word = "Resistant",
            //    Pronunciation = "rɪˈzɪstənt",
            //    Meaning = "Kháng, chống lại"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 759,
            //    Word = "Superb",
            //    Pronunciation = "sʊˈpɜrb",
            //    Meaning = "Tuyệt vời, đặc sắc"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 760,
            //    Word = "Array",
            //    Pronunciation = "əˈreɪ",
            //    Meaning = "Mảng, chủng loại"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 761,
            //    Word = "Informative",
            //    Pronunciation = "ɪnˈfɔrmətɪv",
            //    Meaning = "Nhiều thông tin"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 762,
            //    Word = "Nationwide",
            //    Pronunciation = "ˈneɪʃənˈwaɪd",
            //    Meaning = "Toàn quốc",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 763,
            //    Word = "Outdate",
            //    Pronunciation = "ˈaʊtˌdeɪt",
            //    Meaning = "Lỗi thời",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 764,
            //    Word = "Shareholder",
            //    Pronunciation = "ˈʃɛrˌhoʊldər",
            //    Meaning = "Cổ đông",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 765,
            //    Word = "Voucher",
            //    Pronunciation = "ˈvaʊʧər",
            //    Meaning = "Phiếu quà tặng",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 766,
            //    Word = "Adjacent",
            //    Pronunciation = "əˈʤeɪsənt",
            //    Meaning = "Liền kề",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 767,
            //    Word = "Correspondence",
            //    Pronunciation = "ˌkɔrəˈspɑndəns",
            //    Meaning = "Thư tín",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 768,
            //    Word = "Detergent",
            //    Pronunciation = "dɪˈtɜrʤənt",
            //    Meaning = "Chất tẩy rửa, xà bông giặt",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 769,
            //    Word = "Duration",
            //    Pronunciation = "ˈdʊˈreɪʃən",
            //    Meaning = "Thời lượng",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 770,
            //    Word = "Functional",
            //    Pronunciation = "ˈfʌŋkʃənəl",
            //    Meaning = "Chức năng, có thể dùng được",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 771,
            //    Word = "Hands-on",
            //    Pronunciation = "hændz-ɔn",
            //    Meaning = "Thực hành",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 772,
            //    Word = "Intensive",
            //    Pronunciation = "ɪnˈtɛnsɪv",
            //    Meaning = "Chuyên sâu, học cấp tốc",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 773,
            //    Word = "Last-minute",
            //    Pronunciation = "læst-ˈmɪnət",
            //    Meaning = "Phút chót",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 774,
            //    Word = "Thrilled",
            //    Pronunciation = "θrɪld",
            //    Meaning = "Hồi hộp",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 775,
            //    Word = "Spectacular",
            //    Pronunciation = "spɛkˈtækjələr",
            //    Meaning = "Đẹp mắt",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 776,
            //    Word = "Entrepreneur",
            //    Pronunciation = "ˌɑntrəprəˈnʊr",
            //    Meaning = "Doanh nhân lớn",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 777,
            //    Word = "Introductory",
            //    Pronunciation = "ˌɪntroʊˈdʌktəri",
            //    Meaning = "Nhập môn, đại cương",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 778,
            //    Word = "Minimize",
            //    Pronunciation = "ˈmɪnəˌmaɪz",
            //    Meaning = "Giảm thiểu",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 779,
            //    Word = "Prestigious",
            //    Pronunciation = "prɛˈstɪʤəs",
            //    Meaning = "Uy tín",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 780,
            //    Word = "Screening",
            //    Pronunciation = "ˈskrinɪŋ",
            //    Meaning = "Sàng lọc",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 781,
            //    Word = "Amenity",
            //    Pronunciation = "əˈmɛnəti",
            //    Meaning = "Cơ sở vật chất của 1 nơi chốn",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 782,
            //    Word = "Lengthy",
            //    Pronunciation = "ˈlɛŋθi",
            //    Meaning = "Dài dòng",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 783,
            //    Word = "Compensate",
            //    Pronunciation = "ˈkɑmpənˌseɪt",
            //    Meaning = "Đền bù",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 784,
            //    Word = "Misplace",
            //    Pronunciation = "mɪsˈpleɪs",
            //    Meaning = "Để sai chỗ",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 785,
            //    Word = "Notable",
            //    Pronunciation = "ˈnoʊtəbəl",
            //    Meaning = "Đáng chú ý",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 786,
            //    Word = "Subsidiary",
            //    Pronunciation = "səbˈsɪdiˌɛri",
            //    Meaning = "Công ty con, giao khoán",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 787,
            //    Word = "Authentic",
            //    Pronunciation = "ɔˈθɛntɪk",
            //    Meaning = "Xác thực, chính hiệu",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 788,
            //    Word = "Designate",
            //    Pronunciation = "ˈdɛzɪgneɪt",
            //    Meaning = "Chỉ định",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 789,
            //    Word = "Disruption",
            //    Pronunciation = "dɪsˈrʌpʃən",
            //    Meaning = "Sự gián đoạn",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 790,
            //    Word = "Fragile",
            //    Pronunciation = "ˈfræʤəl",
            //    Meaning = "Mong manh, dễ vỡ",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 791,
            //    Word = "Ongoing",
            //    Pronunciation = "ˈɔnˌgoʊɪŋ",
            //    Meaning = "Đang thực hiện",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 792,
            //    Word = "Periodical",
            //    Pronunciation = "ˌpɪriˈɑdɪkəl",
            //    Meaning = "Định kỳ",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 793,
            //    Word = "Plumber",
            //    Pronunciation = "ˈplʌmər",
            //    Meaning = "Thợ sửa ống nước",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 794,
            //    Word = "Incur",
            //    Pronunciation = "ɪnˈkɜr",
            //    Meaning = "Phát sinh",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 795,
            //    Word = "Oversee",
            //    Pronunciation = "ˈoʊvərˌsi",
            //    Meaning = "Giám sát",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 796,
            //    Word = "Retrieve",
            //    Pronunciation = "rɪˈtriv",
            //    Meaning = "Lấy lại",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 797,
            //    Word = "Reunion",
            //    Pronunciation = "riˈunjən",
            //    Meaning = "Sum họp. Đoàn tụ",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 798,
            //    Word = "Rigorous",
            //    Pronunciation = "ˈrɪgərəs",
            //    Meaning = "Nghiêm ngặt, chặt chẽ",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 799,
            //    Word = "Specification",
            //    Pronunciation = "ˌspɛsɪfɪˈkeɪʃən",
            //    Meaning = "Thông số kỹ thuật",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 800,
            //    Word = "Tentative",
            //    Pronunciation = "ˈtɛntətɪv",
            //    Meaning = "Dự kiến, tạm thời",
            //});
            //#endregion

            //#region 801-900

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 801,
            //    Word = "Tutorial",
            //    Pronunciation = "tuˈtɔriəl",
            //    Meaning = "Bài hướng dẫn",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 802,
            //    Word = "Apprentice",
            //    Pronunciation = "əˈprɛntɪs",
            //    Meaning = "Thợ học nghề",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 803,
            //    Word = "Bid",
            //    Pronunciation = "bɪd",
            //    Meaning = "Bỏ thầu, đấu giá"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 804,
            //    Word = "Discard",
            //    Pronunciation = "dɪˈskɑrd",
            //    Meaning = "Vứt bỏ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 805,
            //    Word = "Outing",
            //    Pronunciation = "ˈaʊtɪŋ",
            //    Meaning = "Chuyến đi chơi"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 806,
            //    Word = "Overwhelmingly",
            //    Pronunciation = "ˌoʊvərˈwɛlmɪŋli",
            //    Meaning = "Choáng ngợp"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 807,
            //    Word = "Proceeds",
            //    Pronunciation = "proʊˈsidz",
            //    Meaning = "Tiền thu được"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 808,
            //    Word = "Refrain",
            //    Pronunciation = "rɪˈfreɪn",
            //    Meaning = "Hạn chế"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 809,
            //    Word = "Inclement",
            //    Pronunciation = "ɪnˈklɛmənt",
            //    Meaning = "Không thuận lợi"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 810,
            //    Word = "Novice",
            //    Pronunciation = "ˈnɑvəs",
            //    Meaning = "Người mới"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 811,
            //    Word = "Activate",
            //    Pronunciation = "ˈæktəˌveɪt",
            //    Meaning = "Kích hoạt"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 812,
            //    Word = "Anecdote",
            //    Pronunciation = "ˈænəkˌdoʊt",
            //    Meaning = "Giai thoại"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 813,
            //    Word = "Collaboration",
            //    Pronunciation = "kəˌlæbəˈreɪʃən",
            //    Meaning = "Sự hợp tác"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 814,
            //    Word = "Commemorate",
            //    Pronunciation = "kəˈmɛməˌreɪt",
            //    Meaning = "Kỷ niệm"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 815,
            //    Word = "Duplicate",
            //    Pronunciation = "ˈdupləkət",
            //    Meaning = "Bản sao"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 816,
            //    Word = "Intermission",
            //    Pronunciation = "ˌɪntərˈmɪʃən",
            //    Meaning = "Phần nghỉ giải lao"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 817,
            //    Word = "Fertilizer",
            //    Pronunciation = "ˈfɜrtəˌlaɪzər",
            //    Meaning = "Phân bón"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 818,
            //    Word = "Proofread",
            //    Pronunciation = "ˈpruˌfrid",
            //    Meaning = "Hiệu đính"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 819,
            //    Word = "Solicit",
            //    Pronunciation = "səˈlɪsɪt",
            //    Meaning = "Kêu gọi"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 820,
            //    Word = "Unveil",
            //    Pronunciation = "ənˈveɪl",
            //    Meaning = "Hé lộ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 821,
            //    Word = "Applicable",
            //    Pronunciation = "ˈæpləkəbəl",
            //    Meaning = "Áp dụng được"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 822,
            //    Word = "Commend",
            //    Pronunciation = "kəˈmɛnd",
            //    Meaning = "Khen ngợi"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 823,
            //    Word = "Complement",
            //    Pronunciation = "ˈkɑmpləmənt",
            //    Meaning = "Bổ sung"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 824,
            //    Word = "Incentive",
            //    Pronunciation = "ɪnˈsɛntɪv",
            //    Meaning = "Khuyến khích"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 825,
            //    Word = "Incorporate",
            //    Pronunciation = "ɪnˈkɔrpəˌreɪt",
            //    Meaning = "Kết hợp"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 826,
            //    Word = "Lapse",
            //    Pronunciation = "læps",
            //    Meaning = "Khoảng thời gian"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 827,
            //    Word = "Picturesque",
            //    Pronunciation = "ˈpɪkʧərəsk",
            //    Meaning = "Đẹp như tranh vẽ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 828,
            //    Word = "Prospective",
            //    Pronunciation = "prəˈspɛktɪv",
            //    Meaning = "Đầy triển vọng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 829,
            //    Word = "Simplify",
            //    Pronunciation = "ˈsɪmpləˌfaɪ",
            //    Meaning = "Đơn giản hóa"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 830,
            //    Word = "Surpass",
            //    Pronunciation = "sərˈpæs",
            //    Meaning = "Vượt qua"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 831,
            //    Word = "Surplus",
            //    Pronunciation = "ˈsɜrpləs",
            //    Meaning = "Số dư"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 832,
            //    Word = "Withstand",
            //    Pronunciation = "wɪθˈstænd",
            //    Meaning = "Chịu được"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 833,
            //    Word = "Advocate",
            //    Pronunciation = "ˈædvəkət",
            //    Meaning = "Biện hộ, người ủng hộ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 834,
            //    Word = "Aspiring",
            //    Pronunciation = "əˈspaɪrɪŋ",
            //    Meaning = "Đầy khát vọng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 835,
            //    Word = "Assorted",
            //    Pronunciation = "əˈsɔrtɪd",
            //    Meaning = "Thập cẩm"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 836,
            //    Word = "Credentials",
            //    Pronunciation = "krəˈdɛnʃəlz",
            //    Meaning = "Bằng cấp nói chung"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 837,
            //    Word = "Interoffice",
            //    Pronunciation = "ˌɪntərˈɔfəs",
            //    Meaning = "Liên ngành"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 838,
            //    Word = "Malfunction",
            //    Pronunciation = "mælˈfʌŋkʃən",
            //    Meaning = "Sự cố, hư hỏng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 839,
            //    Word = "Mutually",
            //    Pronunciation = "ˈmjuʧuəli",
            //    Meaning = "Có điểm chung"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 840,
            //    Word = "Periodically",
            //    Pronunciation = "ˌpiriˈɑdɪkəli",
            //    Meaning = "Định kỳ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 841,
            //    Word = "Copyright",
            //    Pronunciation = "ˈkɑpiˌraɪt",
            //    Meaning = "Bản quyền"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 842,
            //    Word = "Nutritious",
            //    Pronunciation = "nuˈtrɪʃəs",
            //    Meaning = "Bổ dưỡng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 843,
            //    Word = "Obstruct",
            //    Pronunciation = "əbˈstrʌkt",
            //    Meaning = "Cản trở"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 844,
            //    Word = "Abundant",
            //    Pronunciation = "əˈbʌndənt",
            //    Meaning = "Dồi dào",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 845,
            //    Word = "Agreeable",
            //    Pronunciation = "əˈgriəbəl",
            //    Meaning = "Đồng tình",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 846,
            //    Word = "Compromise",
            //    Pronunciation = "ˈkɑmprəˌmaɪz",
            //    Meaning = "Thỏa hiệp",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 847,
            //    Word = "Continuous",
            //    Pronunciation = "kənˈtɪnjuəs",
            //    Meaning = "Liên tiếp",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 848,
            //    Word = "Dominant",
            //    Pronunciation = "ˈdɑmənənt",
            //    Meaning = "Có ưu thế",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 849,
            //    Word = "Exhausted",
            //    Pronunciation = "ɪgˈzɑstɪd",
            //    Meaning = "Kiệt sức",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 850,
            //    Word = "Fierce",
            //    Pronunciation = "fɪrs",
            //    Meaning = "Khốc liệt",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 851,
            //    Word = "Prosperous",
            //    Pronunciation = "ˈprɑspərəs",
            //    Meaning = "Thịnh vượng",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 852,
            //    Word = "Quote",
            //    Pronunciation = "kwoʊt",
            //    Meaning = "Trích dẫn",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 853,
            //    Word = "Reluctant",
            //    Pronunciation = "rɪˈlʌktənt",
            //    Meaning = "Lưỡng lự",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 854,
            //    Word = "Remedy",
            //    Pronunciation = "ˈrɛmədi",
            //    Meaning = "Biện pháp khắc phục, phương thuốc",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 855,
            //    Word = "Solely",
            //    Pronunciation = "ˈsoʊəli",
            //    Meaning = "Đơn, lẻ, duy nhất",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 856,
            //    Word = "Vital",
            //    Pronunciation = "ˈvaɪtəl",
            //    Meaning = "Quan trọng",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 857,
            //    Word = "Revitalize",
            //    Pronunciation = "riˈvaɪtəˌlaɪz",
            //    Meaning = "Hồi sinh, làm sống lại",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 858,
            //    Word = "Commence",
            //    Pronunciation = "kəˈmɛns",
            //    Meaning = "Bắt đầu",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 859,
            //    Word = "Countless",
            //    Pronunciation = "ˈkaʊntləs",
            //    Meaning = "Vô số",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 860,
            //    Word = "Devise",
            //    Pronunciation = "dɪˈvaɪs",
            //    Meaning = "Nghĩ ra, soạn thảo",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 861,
            //    Word = "Execute",
            //    Pronunciation = "ˈɛksəˌkjut",
            //    Meaning = "Thi hành",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 862,
            //    Word = "Foster",
            //    Pronunciation = "ˈfɑstər",
            //    Meaning = "Bồi dưỡng, nhận nuôi",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 863,
            //    Word = "Initiate",
            //    Pronunciation = "ɪˈnɪʃiˌeɪt",
            //    Meaning = "Khởi xướng",
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 864,
            //    Word = "Insight",
            //    Pronunciation = "ˈɪnˌsaɪt",
            //    Meaning = "Cái nhìn sâu sắc"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 865,
            //    Word = "Misleading",
            //    Pronunciation = "mɪsˈlidɪŋ",
            //    Meaning = "Gây hiểu lầm"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 866,
            //    Word = "Precaution",
            //    Pronunciation = "priˈkɔʃən",
            //    Meaning = "Đề phòng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 867,
            //    Word = "Transparent",
            //    Pronunciation = "trænˈspɛrənt",
            //    Meaning = "Trong suốt, xuyên thấu"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 868,
            //    Word = "Coincide",
            //    Pronunciation = "ˌkoʊɪnˈsaɪd",
            //    Meaning = "Trùng hợp"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 869,
            //    Word = "Concise",
            //    Pronunciation = "kənˈsaɪs",
            //    Meaning = "Ngắn gọn"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 870,
            //    Word = "Delegation",
            //    Pronunciation = "ˌdɛləˈgeɪʃən",
            //    Meaning = "Phái đoàn"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 871,
            //    Word = "Diagnosis",
            //    Pronunciation = "ˌdaɪəgˈnoʊsəs",
            //    Meaning = "Chẩn đoán"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 872,
            //    Word = "Enforce",
            //    Pronunciation = "ɛnˈfɔrs",
            //    Meaning = "Thi hành"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 873,
            //    Word = "Hypothesis",
            //    Pronunciation = "haɪˈpɑθəsɪs",
            //    Meaning = "Giả thuyết"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 874,
            //    Word = "Predecessor",
            //    Pronunciation = "ˈprɛdəˌsɛsər",
            //    Meaning = "Người tiền nhiệm"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 875,
            //    Word = "Prominently",
            //    Pronunciation = "ˈprɑmənəntli",
            //    Meaning = "Nổi bật"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 876,
            //    Word = "Adoption",
            //    Pronunciation = "əˈdɑpʃən",
            //    Meaning = "Sự áp dụng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 877,
            //    Word = "Accelerate",
            //    Pronunciation = "ækˈsɛləˌreɪt",
            //    Meaning = "Đẩy nhanh, tăng tốc"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 878,
            //    Word = "Adhere",
            //    Pronunciation = "ədˈhɪr",
            //    Meaning = "Tuân thủ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 879,
            //    Word = "Allocate",
            //    Pronunciation = "ˈæləˌkeɪt",
            //    Meaning = "Chỉ định, bố trí"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 880,
            //    Word = "Appraisal",
            //    Pronunciation = "əˈpreɪzəl",
            //    Meaning = "Thẩm định, định giá"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 881,
            //    Word = "Compile",
            //    Pronunciation = "kəmˈpaɪl",
            //    Meaning = "Tổng hợp, sưu tầm"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 882,
            //    Word = "Conform",
            //    Pronunciation = "kənˈfɔrm",
            //    Meaning = "Tuân thủ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 883,
            //    Word = "Constraint",
            //    Pronunciation = "kənˈstreɪnt",
            //    Meaning = "Hạn chế"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 884,
            //    Word = "Distraction",
            //    Pronunciation = "dɪˈstrækʃən",
            //    Meaning = "Sự đánh lạc hướng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 885,
            //    Word = "Facilitate",
            //    Pronunciation = "fəˈsɪləˌteɪt",
            //    Meaning = "Tạo điều kiện, hỗ trợ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 886,
            //    Word = "Integral",
            //    Pronunciation = "ˈɪntəgrəl",
            //    Meaning = "Quan trọng"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 887,
            //    Word = "Interact",
            //    Pronunciation = "ˌɪntərˈækt",
            //    Meaning = "Tương tác"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 888,
            //    Word = "Persistence",
            //    Pronunciation = "pərˈsɪstəns",
            //    Meaning = "Sự kiên trì"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 889,
            //    Word = "Quota",
            //    Pronunciation = "ˈkwoʊtə",
            //    Meaning = "Hạn mức, mục tiêu"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 890,
            //    Word = "Congested",
            //    Pronunciation = "kənˈʤɛstɪd",
            //    Meaning = "Nghẽn, kẹt xe"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 891,
            //    Word = "Deduct",
            //    Pronunciation = "dɪˈdʌkt",
            //    Meaning = "Khấu trừ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 892,
            //    Word = "Embrace",
            //    Pronunciation = "ɪmˈbreɪs",
            //    Meaning = "Đón nhận, ôm chặt"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 893,
            //    Word = "Synthetic",
            //    Pronunciation = "sɪnˈθɛtɪk",
            //    Meaning = "Sợi tổng hợp"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 894,
            //    Word = "Terminate",
            //    Pronunciation = "ˈtɜrməˌneɪt",
            //    Meaning = "Chấm dứt"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 895,
            //    Word = "Detect",
            //    Pronunciation = "dɪˈtɛkt",
            //    Meaning = "Phát hiện"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 896,
            //    Word = "Patiently",
            //    Pronunciation = "ˈpeɪʃəntli",
            //    Meaning = "Kiên nhẫn"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 897,
            //    Word = "Ratio",
            //    Pronunciation = "ˈreɪʃiˌoʊ",
            //    Meaning = "Tỉ lệ"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 898,
            //    Word = "Dietary",
            //    Pronunciation = "ˈdaɪəˌtɛri",
            //    Meaning = "Chế độ ăn uống"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 899,
            //    Word = "Intentionally",
            //    Pronunciation = "ɪnˈtɛnʃənəli",
            //    Meaning = "Cố ý"
            //});

            //vocabularyWords.Add(new TempVocabularyWord
            //{
            //    VocabularyId = 900,
            //    Word = "Persuasive",
            //    Pronunciation = "pərˈsweɪsɪv",
            //    Meaning = "Mang tính thuyết phục"
            //});
            //#endregion

            return vocabularyWords;
        }
    }
}
