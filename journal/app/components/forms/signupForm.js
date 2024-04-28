'use client'
import React from "react"

export default function SignUpForm()
{
    return(
        <div class="w-96 border"> 
        <div class="bg-pink-900 text-white text-center h-28 grid place-items-center rounded-t-lg"> 
        <h3 class="text-2xl">Create Account</h3>
        </div> 
        <div class="p-4">
             <div class="mb-4"> 
             <label for="name" class="block text-gray-700 font-bold mb-2">Full Name</label> 
             <input type="text" id="name" name="name" placeholder="enter full name" class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" required /> 
             </div> 
             <div class="mb-4"> 
             <label for="name" class="block text-gray-700 font-bold mb-2">user name</label> 
             <input type="text" id="name" name="name" class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" required /> 
             </div> 
             <div class="mb-4">
                 <label for="email" class="block text-gray-700 font-bold mb-2">email address</label>
                  <input type="email" id="email" name="email" class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" required /> 
                  </div>
                   <div class="mb-4">
                     <label for="password" class="block text-gray-700 font-bold mb-2">enter password</label> 
                     <input type="password" id="password" name="password" class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" required /> 
                     </div> 
                     
                            </div>
                             <div class="bg-pink-900 text-white text-center p-4 rounded-b-lg">
                                 <button class="bg-white text-teal-900 font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" >
                                    Create Account
                                    </button> 
                                    <p class="text-sm mt-4">have an account? proceed to <a href="/login" class="text-blue-gray font-bold">Sign in</a></p> 
                                    <p class="text-center text-white-500 text-xs">
                                        &copy;2024 Max Mulla. All rights reserved.
                                    </p>
                                    </div>
</div>
    )
}