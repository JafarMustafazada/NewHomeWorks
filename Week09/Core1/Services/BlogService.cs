using Core1.Exceptions;
using Core1.Helpers;
using Core1.Models;
using System.Data;

namespace Core1.Services;

public static class BlogService
{
    public static List<Blogs> GetAll()
    {
        List<Blogs> blogs = new List<Blogs>();
        DataTable dt = SqlHelper.GetDatas(SqlHelper.QGetAll("Blogs"));

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            blogs.Add(new Blogs()
            {
                Id = (int)dt.Rows[i]["ID"],
                Title = (string)dt.Rows[i]["Title"],
                Describtion = (string)dt.Rows[i]["Describtion"],
                UserId = (int)dt.Rows[i]["User_ID"]
            });
        }

        return blogs;
    }

    public static Blogs GetById(int id)
    {
        DataTable dt = SqlHelper.GetDatas(SqlHelper.QGetById("Blogs", id));
        if (dt.Rows.Count < 1) throw new NoSearchResultException();
        return new Blogs() {
            Id = (int)dt.Rows[0]["ID"],
            Title = (string)dt.Rows[0]["Title"],
            Describtion = (string)dt.Rows[0]["Describtion"],
            UserId = (int)dt.Rows[0]["User_ID"]
        };
    }

}
