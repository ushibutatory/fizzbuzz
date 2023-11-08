"use client";

import React from "react";
import styles from "./page.module.scss";
import Form from "../components/form";

const Page = () => {
  return (
    <main className={styles.main}>
      <nav className="navbar navbar-expand-lg bg-body-tertiary">
        <div className="container-fluid">
          <div className="navbar-brand">
            <h1>NabeAtsu.API</h1>
          </div>
          <button
            className="navbar-toggler"
            type="button"
            data-bs-toggle="collapse"
            data-bs-target="#navItems"
            aria-controls="navItems"
            aria-expanded="false"
            aria-label="Toggle navigation"
          >
            <span className="navbar-toggler-icon"></span>
          </button>
          <div className="collapse navbar-collapse" id="navItems">
            <ul className="navbar-nav">
              <li className="nav-item">
                <a className="nav-link" href="https://github.com/ushibutatory/fizzbuzz" target="_blank">
                  <i className="bi bi-github"></i> GitHub
                </a>
              </li>
              <li className="nav-item">
                <a className="nav-link" href="https://twitter.com/ushibutatory" target="_blank">
                  <i className="bi bi-twitter"></i> X (Twitter)
                </a>
              </li>
            </ul>
          </div>
        </div>
      </nav>
      <div className="container">
        <div className={styles.explain}>
          <p>数値を以下ルールで変換します。</p>
          <div>
            <ul>
              <li>3の倍数と3のつく数の時、アホになります。</li>
              <li>5の倍数の時、犬になります。</li>
              <li>両方の条件を満たす時、アホな犬になります。</li>
            </ul>
          </div>
        </div>
        <Form />
      </div>
    </main>
  );
};

export default Page;
