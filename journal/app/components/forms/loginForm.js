'use client'
import { useSession } from "next-auth/react"
import React, { useState, useEffect } from "react"
import { toast } from "react-toastify"
import { useRouter } from "next/navigation"
import axios from "axios"

export default function LoginForm(){
  const router = useRouter();
  const session = useSession();
  const [email, setEmail] = useState()
  const [password, setPassword] = useState()

  useEffect(() => {
    console.log(session)
    if (session?.status === "authenticated") {
      router.push("/profile")
    }
  }, [session?.status])

  const handleLogin = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post("http://localhost:5103/api/User/login", { email, password })
      console.log(response)
      toast.success("User Logged in successfully")
      
    } catch (error) {
      console.log(error)
      toast.error("something went wrong! Please check credentials")
    }
     
    }
  
    return(
      <div className="w-full max-w-xs">
        <form className="bg-white shadow-md rounded px-8 pt-6 pb-8 mb-4">
          <div className="mb-4">
            <label className="block text-gray-700 text-sm font-bold mb-2" for="email">
              Email
            </label>
              <input 
                className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" 
                id="email"
                value={email}
                type="email" 
                placeholder="Enter Email"
                onChange={(e) => setEmail(e.target.value)} 
                />
          </div>
    <div className="mb-6">
      <label className="block text-gray-700 text-sm font-bold mb-2" for="password">
        Password
      </label>
      <input 
        className="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 mb-3 leading-tight focus:outline-none focus:shadow-outline"  
        id="password"
        value={password} 
        type="password"
        placeholder="Enter Password" 
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