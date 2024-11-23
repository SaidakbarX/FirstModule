using CrudPostInst.modul;
namespace CrudPostInst.service;

public class ServiceInst
{
    private List<model> posts;
    public ServiceInst()
    {
        posts = new List<model>();
    }
    public model AddPost(model post)
    {
        post.Id = Guid.NewGuid();
        posts.Add(post);
        return post;
    }
    public List<model> GetPosts()
    {
        return posts;
    }
    public model GetByPost(Guid id)
    {
        foreach (model model in posts)
        {
            if (model.Id == id) return model;
        }
        return null;
    }
    public bool UpdatePost(model updatePost)
    {
        var postFromdb = GetByPost(updatePost.Id);
        if (postFromdb is null)
        {
            return false;
        }
        var index = posts.IndexOf(postFromdb);
        posts[index] = updatePost;
        return true;
    }
    public bool DeletePost(Guid id)
    {
        var post = GetByPost(id);
        if (post is null)
        {
            return false;
        }
        posts.Remove(post);
        return true;
    }
    public model GetMostViewedPost()
    {
        model post = null;
        var postVeiw = 0;
        foreach (var model in posts)
        {
            if (model.ViewerName.Count > postVeiw)
            {
                postVeiw = model.ViewerName.Count;
                post = model;
            }
        }
        return post;
    }
    public model GetMostLikedPost()
    {
        model post = null;
        var postVeiw = 0;
        foreach (var model in posts)
        {
            if (model.QuentyLikes > postVeiw)
            {
                postVeiw = (int)model.QuentyLikes;
                post = model;
            }
        }
        return post;
    }
    public model GetMostCommentedPost()
    {
        model post = null;
        var postVeiw = 0;
        foreach (var model in posts)
        {
            if (model.Comments.Count > postVeiw)
            {
                postVeiw = model.Comments.Count;
                post = model;
            }
        }
        return post;
    }
    public List<model> GetPostsByComment(string comment)
    {
        var commetedPost = new List<model>();
        foreach (var model in posts)
        {
            var commets = model.Comments;
            if (comment.Contains(comment) is true)
            {
                commetedPost.Add(model);
            }
        }
        return commetedPost;
    }
}
