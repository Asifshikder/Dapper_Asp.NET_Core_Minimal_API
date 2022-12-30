using Microsoft.AspNetCore.Mvc;

namespace Minimal
{
    public static class Api
    {
        public static void ConfigureApi(this WebApplication application)
        {
            application.MapGet("/getusers", GetUsers);
            application.MapGet("/getuser/{id}", GetUser);
            application.MapPost("/adduser", AddUser);
            application.MapPut("/updateuser", UpdateUser);
            application.MapDelete("/deleteuser", DeleteUser);
        }
        public static async Task<IResult> GetUsers(IUserData userData)
        {
            try
            {
                return Results.Ok(await userData.GetAllUser());
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        public static async Task<IResult> GetUser(int id,IUserData userData)
        {
            try
            {
                var result =await userData.GetUser(id);
                if(result==null)
                    return Results.NotFound();
                return Results.Ok(result);
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        public static async Task<IResult> AddUser(UserModel user,IUserData userData)
        {
            try
            {
                await userData.InsertUser(user);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        public static async Task<IResult> UpdateUser(UserModel user,IUserData userData)
        {
            try
            {
                await userData.UpdateUser(user);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
        public static async Task<IResult> DeleteUser(int id,IUserData userData)
        {
            try
            {
                await userData.DeleteUser(id);
                return Results.Ok();
            }
            catch (Exception ex)
            {
                return Results.Problem(ex.Message);
            }
        }
    }
}
