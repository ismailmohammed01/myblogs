import React, { useState, useEffect } from 'react';
import axios from 'axios';

const BlogList = () => {
  const [blogs, setBlogs] = useState([]);

  useEffect(() => {
    // Make an API request to fetch the blog data
    axios.get('http://localhost:2387/api/Blog')
      .then(async (response) => {
        // Fetch images for each blog post from picsum
        const blogsWithImages = response.data.map((blog) => {
          // Generate a random image URL using the provided link
          const imageUrl = `https://picsum.photos/200?random=${blog.blogId}`;
          return { ...blog, imageUrl };
        });
        setBlogs(blogsWithImages);
      })
      .catch(error => {
        console.error('Error fetching data:', error);
      });
  }, []);

  return (
    <div>
      <h1>Blog List</h1>
      <ul>
        {blogs.map(blog => (
          <li key={blog.blogId}>
            <h2>{blog.title}</h2>
            <img src={blog.imageUrl} alt="Blog" />
            <p>{blog.content}</p>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default BlogList;
