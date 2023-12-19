using HikiStudio.LearnVocabulary.APIIntegration.Interfaces;
using HikiStudio.LearnVocabulary.APIIntegration.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

builder.Services.AddHttpClient();

// Add services to the container.
builder.Services.AddControllersWithViews();

//DI
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<IMp3APIClient, Mp3APIClient>();

builder.Services.AddScoped<IVocabularyTypeAPIClient, VocabularyTypeAPIClient>();
builder.Services.AddScoped<IVocabularyWordAPIClient, VocabularyWordAPIClient>();
builder.Services.AddScoped<IVocabularyLearningLogAPIClient, VocabularyLearningLogAPIClient>();
builder.Services.AddScoped<ICourseAPIClient, CourseAPIClient>();
builder.Services.AddScoped<IFavouriteCourseAPIClient, FavouriteCourseAPIClient>();
builder.Services.AddScoped<ICourseLearningLogAPIClient, CourseLearningLogAPIClient>();
builder.Services.AddScoped<IVocabularyRelationshipAPIClient, VocabularyRelationshipAPIClient>();

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
