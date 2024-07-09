'use client'
import {signIn, useSession } from "next-auth/react"
import React, { useState, useEffect } from "react"
import { toast } from "react-toastify"
import { useRouter } from "next/navigation"


export default function LoginForm(){
  const router = useRouter();
  const session = useSession();
  const [username, setUsername] = useState()
  const [password, setPassword] = useState()

  useEffect(() => {
    console.log(session)
    if (session?.status === "authenticated") {
      router.push("/profile")
    }
  }, [session?.status])

  const handleLogin = async (e) => {
    e.preventDefault();
    let data = { username, password };
    signIn("credentials", { ...data, redirect: false }).then((callback) => {
      if (callback?.error) {
        toast.error(callback.error);
      }

      if (callback?.ok && !callback?.error) {
        toast.success("Logged in successfully!");
      }
    });
  };
  
    return(
      <div className="w-full max-w-xs">
        <form className="bg-white shadow-md rounded px-8 pt-6 pb-8 mb-4">
          <div className="mb-4">
            <label className="block text-gray-700 text-sm font-bold mb-2">
              Username
            </label>
              <input 
                className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                id="username"
                value={username}
                type="text"
                onChange={(e) => setUsername(e.target.value)} 
                />
          </div>
    <div className="mb-6">
      <label className="block text-gray-700 text-sm font-bold mb-2" >
        Password
      </label>
      <input 
        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 mb-3 leading-tight focus:outline-none focus:shadow-outline"  
        id="password"
        value={password} 
        type="password"
        // placeholder="Enter Password" 
        onChange={(e) => setPassword(e.target.value)}
        />
      
    </div>
    <div className="flex items-center justify-between">
      <button 
        className="bg-pink-700 hover:bg-pink-900 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" 
        type="button"
        onClick={handleLogin}
        >
        Sign In
      </button>
      <a className="inline-block align-baseline font-bold text-sm text-black hover:text-pink-800" href="#">
        Forgot Password?
      </a>
    </div>
  </form>
  <p className="text-center text-gray-500 text-xs">
    &copy;2024 Max Mulla. All rights reserved.
  </p>
</div>
    )
}