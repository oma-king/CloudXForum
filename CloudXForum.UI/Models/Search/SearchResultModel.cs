﻿using CloudXForum.UI.Models.Post;

namespace CloudXForum.UI.Models.Search;

public class SearchResultModel
{
    public IEnumerable<PostListingModel> Posts { get; set; }
    public string SearchQuery { get; set; }
    public bool EmptySearchResults { get; set; }
}