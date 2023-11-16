const Nav = () => {
  return (
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
                <i className="fa-brands fa-github"></i> GitHub
              </a>
            </li>
            <li className="nav-item">
              <a className="nav-link" href="https://twitter.com/ushibutatory" target="_blank">
                <i className="fa-brands fa-x-twitter"></i> X (Twitter)
              </a>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  );
};

export default Nav;
